using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;


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
                //為接受数据創建一个线程
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
                    //通過clientSocket接收數據  
                    int receiveNumber = connection.Receive(result);
                    //把接受的數據從字節類型轉化為字符類型
                    String recStr = Encoding.ASCII.GetString(result, 0, receiveNumber);


                    //獲取當前客户端的ip地址
                    IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                    //獲取客户端端口
                    int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;
                    String sendStr = clientIP + ":" + clientPort.ToString() + "--->" + recStr;
                    foreach (Socket socket in sockets)
                    {
                        socket.Send(Encoding.ASCII.GetBytes(sendStr));
                    }
                    //顯示内容
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


    }
    
}
