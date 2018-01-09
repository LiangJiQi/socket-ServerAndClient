using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text12_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            ip = IPAddress.Parse("127.0.0.1");
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            InitializeComponent();
        }
        private static byte[] result = new byte[1024];
        IPAddress ip;
        private Socket clientSocket;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clientSocket.Connect = false;
            //Form1.clientSocket3 = Form1.serverSocket.Accept();
            clientSocket.Send(Encoding.ASCII.GetBytes(textBox2.Text));
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 8885));
                Form1.clientSocket3 = Form1.serverSocket.Accept();
                Form1.clientSocket3.Send(Encoding.ASCII.GetBytes("Welcome to login! Client!"));
                textBox1.Text = "成功连接服务！ 本机地址：端点(" + Form1.clientSocket3.RemoteEndPoint.ToString() + ")";
                Socket myClientSocket = (Socket)clientSocket;
                int receiveNumber = myClientSocket.Receive(result);
                textBox1.Text += "\r\n服务器信息：" + myClientSocket.RemoteEndPoint.ToString() + ":" + Encoding.ASCII.GetString(result, 0, receiveNumber);
            }
            catch
            {
                MessageBox.Show("连接失败！请重试！");
            }
        }
        //public  void reconnect()
        //{
        //    clientSocket.Close();
        //    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    clientSocket.Connect(new IPEndPoint(ip, 8885));
        //    Form1.clientSocket3 = Form1.serverSocket.Accept();
        //    Thread.Sleep(100);
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {

            Socket myClientSocket = (Socket)clientSocket;
            if (result == null || myClientSocket == null)
                return;
            if (clientSocket.Available <= 0)
                return;
            int receiveNumber = myClientSocket.Receive(result);
            textBox1.Text += "\r\n服务器信息：" + " " + Encoding.ASCII.GetString(result, 0, receiveNumber);
            textBox1.AppendText(" ");
            textBox1.ScrollToCaret();
        }
    }
}
