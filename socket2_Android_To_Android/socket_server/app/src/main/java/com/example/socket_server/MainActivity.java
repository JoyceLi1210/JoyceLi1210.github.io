package com.example.socket_server;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class MainActivity extends AppCompatActivity {

    private static final int PORT = 9999;
    private List<Socket> mList = new ArrayList<Socket>();
    private volatile ServerSocket server=null;
    private ExecutorService mExecutorService = null; //線程
    private String hostip; //本機IP
    private TextView mText1;
    private TextView mText2;
    private Button mBut1=null;
    private Handler myHandler=null;
    private volatile boolean flag= false;//线程标志位

    private String msg = "";
    private static int count=0; //計算有幾個 Client 端連線
    private Handler handler = new Handler();
    String s ;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.activity_main);
        hostip = getLocalIpAddress();  //獲取本機IP
        mText1=(TextView) findViewById(R.id.textView1);
        mText1.setText(hostip);
        mText1.setEnabled(false);
        mText2=(TextView) findViewById(R.id.textView2);

        mBut1=(Button) findViewById(R.id.but1);
        mBut1.setOnClickListener(new Button1ClickListener());
        //取得非UI線程傳來的msg，以改變介面
        myHandler =new Handler(){
            @SuppressLint("HandlerLeak")
            public void handleMessage(Message msg){
                if(msg.what==0x1234){
                    mText2.append("\n" + msg.obj.toString());
                }
            }
        };

    }
    //對button1的監聽事件
    private final class Button1ClickListener implements View.OnClickListener{
        @Override
        public void onClick(View v) {
            // TODO Auto-generated method stub
            //如果是「啟動」，證明服務器是關閉狀態，可以開啟服務器
            if(mBut1.getText().toString().equals("啟動")){
                ServerThread serverThread=new ServerThread();
                flag=true;
                serverThread.start();
                mBut1.setText("關閉");
                mText1.setText(getLocalIpAddress());
                //show IP address
                Toast toast = Toast.makeText(MainActivity.this, "IP address: "+getLocalIpAddress(), Toast.LENGTH_LONG);
                toast.show();
            }else{
                try {
                    flag=false;
                    count = 0;

                    server.close();
                    for(int p=0;p<mList.size();p++){
                        Socket s=mList.get(p);
                        s.close();
                    }
                    mExecutorService.shutdownNow();
                    mBut1.setText("啟動");
                    mText1.setText("Not Connect");

                    Log.v("Socket-status","服務器已關閉");
                } catch (IOException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        }
    }

    //Server端的主線程
    class ServerThread extends Thread {
        public void run() {
            try {
                server = new ServerSocket(PORT);
            } catch (IOException e1) {
                e1.printStackTrace();
            }
            mExecutorService = Executors.newCachedThreadPool();  //創建一個線程
            Socket client = null;
            while(flag) {
                try {
                    Log.v("test", String.valueOf(flag));
                    client = server.accept();

                    handler.post(new Runnable() {
                        public void run() {
                            ++count;

                            mText1.setText("現在使用者個數："+ count);
                        }
                    });
                    try {
                        handler.post(new Runnable() {
                            public void run() {
                                mText2.setText(s);  //post message on the textView
                            }
                        });
                    } catch (Exception e) {
                        handler.post(new Runnable() {
                            public void run() {
                                mText2.setText(s);
                            }
                        });
                    }
                    //把客户端放入客户端集合中
                    mList.add(client);
                    mExecutorService.execute(new Service(client)); //啟動一個新的線程來處理連接
                }catch ( IOException e) {
                    e.printStackTrace();
                    handler.post(new Runnable() {
                        public void run() {
                            mText2.setText("disConncet");
                        }
                    });
                }
            }


        }
    }
    //獲取本地IP
    @SuppressLint("LongLogTag")
    public static String getLocalIpAddress() {
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface
                    .getNetworkInterfaces(); en.hasMoreElements();) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf
                        .getInetAddresses(); enumIpAddr.hasMoreElements();) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress() && !inetAddress.isLinkLocalAddress()) {
                        return inetAddress.getHostAddress().toString();
                    }
                }
            }
        } catch (SocketException ex) {
            Log.e("WifiPreference IpAddress", ex.toString());
        }
        return null;
    }
    //處理與client對話的線程
    class Service implements Runnable {
        private volatile boolean kk=true;
        private Socket socket;
        private BufferedReader in = null;
        //private String msg = "";

        public Service(Socket socket) {
            this.socket = socket;   //reada6
            try {
                in = new BufferedReader(new InputStreamReader(socket.getInputStream(),"UTF-8"));
                msg="Action : Connect ( 現在使用者個數："+ count + ")";   //reada8
                this.sendmsg(msg);  //reada9
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public void run() {
            while(kk) {
                try {
                    if((msg = in.readLine())!= null) {
                        //當客戶端發送的訊息為：exit時，關閉連接
                        if(msg.equals("exit:")) {
                            in = new BufferedReader(new InputStreamReader(socket.getInputStream(),"UTF-8"));

                            count--;
                            msg="Action : disconnect ( 現在使用者個數："+ count + ")";
                            this.sendmsg(msg);

                             mText1.setText("現在使用者個數："+ count);

                             mList.remove(socket);
                            break;
                            //接收客户端發過來的訊息msg，然後發送給客戶端。
                        } else {
                            Message msgLocal = new Message();
                            msgLocal.what = 0x1234;
                            msgLocal.obj =msg+" （From Client）" ;

                            System.out.println(msgLocal.obj.toString());
                            System.out.println(msg);
                            myHandler.sendMessage(msgLocal);
                            msg = socket.getInetAddress() + "→" + msg+"（From Server）";
                            this.sendmsg(msg);
                        }
                    }
                } catch (IOException e) {
                    System.out.println("close");
                    kk=false;

                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        }
        //向客戶端發送訊息
        public void sendmsg(String msg) {
            System.out.println(msg);
            PrintWriter pout = null;
            try {
                pout = new PrintWriter(new BufferedWriter(
                        new OutputStreamWriter(socket.getOutputStream())),true);
                pout.println(msg);
            }catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}