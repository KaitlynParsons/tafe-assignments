/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        Methods and events for the student GUI
 *  Known Bugs:     None.
 */
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArithmeticChallengClient
{
    public partial class Form1 : Form
    {
        private const int portNum = 8888;
        delegate void SetTextCallback(string text);
        TcpClient client;
        NetworkStream ns;
        Thread t = null;
        int answer = 0;
        private const string hostName = "localhost";
        /// <summary>
        /// constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient(hostName, portNum);
            ns = client.GetStream();
            string s = "";
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            ns.Write(byteTime, 0, byteTime.Length);
            t = new Thread(DoWork);
            t.Start();
        }

        /// <summary>
        /// exists the application, closes the thread and client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            t.Abort();
            client.Close();
        }

        /// <summary>
        /// submit the answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string s = textAnswer.Text;
            if (s.ToString() == null || s.ToString() == "")
            {
                MessageBox.Show("Please enter an answer!");
                return;
            }
            if (s.ToString() != answer.ToString())
            {
                MessageBox.Show("Incorrect");
            }
            else
            {
                MessageBox.Show("Correct");
            }
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            ns.Write(byteTime, 0, byteTime.Length);
            textQuestion.Text = null;
            textAnswer.Text = null;
        }

        /// <summary>
        /// this is run as a thread
        /// </summary>
        public void DoWork()
        {
            byte[] bytes = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);
                    this.SetText(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// sets the text that is sent
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            string[] pieces;
            if (this.textQuestion.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                if (text.Contains("+"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) + Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("-"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) - Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("x"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) * Convert.ToInt32(pieces[2]);
                }
                if (text.Contains("/"))
                {
                    answer = 0;
                    pieces = text.Split(' ');
                    answer = Convert.ToInt32(pieces[0]) / Convert.ToInt32(pieces[2]);
                }
            }
            else
            {
                this.textQuestion.Text = this.textQuestion.Text + text;
            }
        }
    }
}
