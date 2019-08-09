using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace socket
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        static Socket serverSocket = null;
        static List<Socket> sockets = new List<Socket>();


        public MainWindow()
        {
    
            InitializeComponent();

            

        }
        public void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                sockets.Add(clientSocket);
                //为接受数据创建一个线程
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }
        public void ReceiveMessage(object clientSocket)
        {
            Socket connection = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024];
                    //通过clientSocket接收数据  
                    int receiveNumber = connection.Receive(result);
                    //把接受的数据从字节类型转化为字符类型
                    String recStr = Encoding.ASCII.GetString(result, 0, receiveNumber);


                    //获取当前客户端的ip地址
                    IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                    //获取客户端端口
                    int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;
                    String sendStr = clientIP + ":" + clientPort.ToString() + "--->" + recStr;
                    foreach (Socket socket in sockets)
                    {
                        socket.Send(Encoding.ASCII.GetBytes(sendStr));
                    }
                    //显示内容
                    text1.Dispatcher.BeginInvoke(

                            new Action(() => { text1.Text += "\r\n" + sendStr; }), null);

                }
                catch (Exception ex)
                {

                    connection.Shutdown(SocketShutdown.Both);
                    connection.Close();
                    break;
                }
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPAddress ip = IPAddress.Parse("192.168.43.155");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, 5050));  //绑定IP地址：端口  
            serverSocket.Listen(10);    //设定最多10个排队连接请求             
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();

            
        }

        /*
        private void connect_click(object sender, RoutedEventArgs e)
        {
            System.Net.IPAddress theIPAddress;
            //建立 IPAddress 物件(本機)
            theIPAddress = System.Net.IPAddress.Parse("192.168.43.155");

            //建立監聽物件
            TcpListener myTcpListener = new TcpListener(theIPAddress, 5050);
            //啟動監聽
            myTcpListener.Start();
            txt.AppendText("通訊埠 5050 等待用戶端連線...... !!");
            // Console.WriteLine("通訊埠 5050 等待用戶端連線...... !!");
            Socket mySocket = myTcpListener.AcceptSocket();
            do
            {
                try
                {
                    //偵測是否有來自用戶端的連線要求，若是
                    //用戶端請求連線成功，就會秀出訊息。
                    if (mySocket.Connected)
                    {
                        int dataLength;
                        txt.AppendText("連線成功 !!");
                        byte[] myBufferBytes = new byte[10000];
                        //取得用戶端寫入的資料
                        dataLength = mySocket.Receive(myBufferBytes);

                        txt.AppendText("接收到的資料長度" + dataLength.ToString() + "\n ");
                        txt.AppendText("取出用戶端寫入網路資料流的資料內容 :");
                        txt.AppendText(Encoding.ASCII.GetString(myBufferBytes, 0, dataLength) + "\n");
                        // Console.WriteLine("按下 [任意鍵] 將資料回傳至用戶端 !!");
                        // Console.ReadLine();
                        //將接收到的資料回傳給用戶端
                        mySocket.Send(myBufferBytes, myBufferBytes.Length, 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    mySocket.Close();
                    break;
                }

            } while (true);*/
    }
    
}
