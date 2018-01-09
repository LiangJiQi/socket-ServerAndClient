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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form2 form2;
        private Form3 form3;
        private Form4 form4;
        private static byte[] result = new byte[1024];
        private static int myProt = 8885;
        private string refreshClient;
        public static Socket serverSocket;
        public static Socket clientSocket1;
        public static Socket clientSocket2;
        public static Socket clientSocket3;
        private void button1_Click(object sender, EventArgs e)
        {
            Thread one = new Thread(new ThreadStart(form2Invoker));
            one.Start();
            

        }
        public void form2Invoker()
        {
            MethodInvoker form2Toshow = new MethodInvoker(showForm2);
            this.BeginInvoke(form2Toshow);
        }
        public void showForm2()
        {
           
            
            
            form2 = new Form2();
            
            form2.Show();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));
            serverSocket.Listen(10);
            textBox1.Text = "已启用监听：" + serverSocket.LocalEndPoint.ToString();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread two = new Thread(new ThreadStart(form3Invoker));
            two.Start();
           
        }
        public void form3Invoker()
        {
            MethodInvoker form3Toshow = new MethodInvoker(showForm3);
            this.BeginInvoke(form3Toshow);
        }
        public void showForm3()
        {
            form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread three = new Thread(new ThreadStart(form4Invoker));
            three.Start();
        }
        public void form4Invoker()
        {
            MethodInvoker form4Toshow = new MethodInvoker(showForm4);
            this.BeginInvoke(form4Toshow);
        }
        public void showForm4()
        {
            form4 = new Form4();
            form4.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            acceptClient(clientSocket1);
            acceptClient(clientSocket2);
            acceptClient(clientSocket3);
        }
        public void acceptClient(Socket _client)
        {
            if (_client == null)
                return;
            if (_client.Available <= 0)
                return;
            Socket myClientSocket = (Socket)_client;
            int receiveNumber = myClientSocket.Receive(result);
            refreshClient = myClientSocket.RemoteEndPoint.ToString() + ":" + Encoding.ASCII.GetString(result, 0, receiveNumber);
            textBox1.AppendText("\r\n接收到" + refreshClient);
            textBox1.ScrollToCaret();
        }
            private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sendToClient(clientSocket1);
            sendToClient(clientSocket2);
            sendToClient(clientSocket3);
            
            

        }
        public void sendToClient(Socket _client)
        {
            if (_client == null)
                return;
            if (refreshClient == null)
                return;
            Socket myClientSocket = _client;
            myClientSocket.Send(Encoding.ASCII.GetBytes(refreshClient));
        }
    }
}
