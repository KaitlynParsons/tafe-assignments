/* 
 *  Student Number: 450950837
 *  Name:           Kaitlyn Parsons
 *  Date:           13/09/2018 
 *  Purpose:        Methods and method calls on buttons to display in the main program.
 *  Known Bugs:     None.
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// <see cref="ArithmeticChallenge"/> namespace
/// </summary>
namespace ArithmeticChallenge
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   server form class. </summary>
    ///
    /// <remarks>   Parsons, 16-Sep-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Form1 : Form
    {
        //for text sending

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the set text. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        delegate void SetTextCallback(string text);
        //for listening for connection
        /// <summary>   The listener. </summary>
        TcpListener listener;
        //for client
        /// <summary>   The client. </summary>
        TcpClient client;
        //for the stream of data passed between server and client
        /// <summary>   The ns. </summary>
        NetworkStream ns;
        //for the thread
        /// <summary>   A Thread to process. </summary>
        Thread t = null;
        //for the double link list
        /// <summary>   The list of nodes. </summary>
        NodeList listOfNodes = new NodeList();
        //for the binary tree
        /// <summary>   my tree. </summary>
        BinaryTree myTree = new BinaryTree();
        /// <summary>   The equation. </summary>
        Question equation;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   constructor. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            comboOperator.Items.Add("+");
            comboOperator.Items.Add("-");
            comboOperator.Items.Add("x");
            comboOperator.Items.Add("/");
            listener = new TcpListener(8888);
            listener.Start();
            client = listener.AcceptTcpClient();
            ns = client.GetStream();
            t = new Thread(DoWork);
            t.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   closes the Windows Form. closes thread and client on click or esc key. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            t.Abort();
            client.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   displays answer in answer textbox when second number is entered. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textChanged(object sender, EventArgs e)
        {
            //call method
            autoAnswer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   method calculates answer depending on selected index (+, -, *, /) </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void autoAnswer()
        {
            int first;
            int second;
            if (comboOperator.SelectedIndex == 0)
            {
                int.TryParse(textFirstNum.Text, out first);
                int.TryParse(textSecondNum.Text, out second);
                textAnswer.Text = (first + second).ToString();
            }
            else if (comboOperator.SelectedIndex == 1)
            {
                int.TryParse(textFirstNum.Text, out first);
                int.TryParse(textSecondNum.Text, out second);
                textAnswer.Text = (first - second).ToString();
            }
            else if (comboOperator.SelectedIndex == 2)
            {
                int.TryParse(textFirstNum.Text, out first);
                int.TryParse(textSecondNum.Text, out second);
                textAnswer.Text = (first * second).ToString();
            }
            else if (comboOperator.SelectedIndex == 3)
            {
                if (textSecondNum.Text == "0" || textSecondNum.Text == "")
                {
                    textAnswer.Text = "0";
                }
                else
                {
                    int.TryParse(textFirstNum.Text, out first);
                    int.TryParse(textSecondNum.Text, out second);
                    textAnswer.Text = (first / second).ToString();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   adds equation to a new row in the datagridQuestions. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void saveEquation()
        {
            string firstNum = textFirstNum.Text;
            string operation = comboOperator.Text;
            string secondNum = textSecondNum.Text;
            string equals = "=";
            string Answer = textAnswer.Text;
            DataGridViewRow row = (DataGridViewRow)dataGridQuestions.RowTemplate.Clone();
            row.CreateCells(dataGridQuestions, firstNum, operation, secondNum, equals, Answer);
            dataGridQuestions.Rows.Add(row);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   send the equation to the student. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSend_Click(object sender, EventArgs e)
        {
            int first = Convert.ToInt32(textFirstNum.Text);
            string operation = comboOperator.Text;
            int second = Convert.ToInt32(textSecondNum.Text);
            if (second == 0)
            {
                MessageBox.Show("Cannot divide by zero");
                return;
            }
            string equals = "=";
            byte[] byteTime = Encoding.ASCII.GetBytes(first + " " + operation + " " + second + " " + equals);
            ns.Write(byteTime, 0, byteTime.Length);
            buttonSend.Enabled = false;
            saveEquation();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   this is run as a thread. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   sets the text that is sent. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="text"> . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetText(string text)
        {
            //InvokeRequired required compares the thread ID of the
            //calling thread to the thread ID of the creating thread.
            //if these thread are different, it returns true.
            if (this.richLinkList.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //if the text recieved is incorrect add it to the link list
                if (text != textAnswer.Text)
                {
                    int num;
                    bool answer = int.TryParse(textAnswer.Text, out num);
                    listOfNodes.addAtFrontOfNodeList(new Node(num));
                    richLinkList.Text = listOfNodes.printLinkList(listOfNodes);
                    listOfNodes.linkListTable(listOfNodes);
                }
                equation = new Question(Convert.ToInt32(textFirstNum.Text), Convert.ToInt32(textSecondNum.Text), comboOperator.Text, Convert.ToInt32(textAnswer.Text));
                binaryTree();
                buttonSend.Enabled = true;
                clearEquation();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   this is for displaying the binary tree of all equations. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void binaryTree()
        {
            //if the tree is null
            if (myTree.top == null)
            {
                //create new node equation at the top of the tree
                myTree.top = new BinaryNode(equation);
            }
            else
            {
                //otherwise add another equation to the tree
                myTree.Add(equation);
            }
            richBinaryTree.Clear();
            richBinaryTree.Text = "IN-ORDER: ";
            richBinaryTree.Text += myTree.printInOrder(myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   this is to clear the equation after its sent. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void clearEquation()
        {
            textFirstNum.Text = null;
            comboOperator.Text = null;
            textSecondNum.Text = null;
            textAnswer.Text = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   prevents cells being highlighted in datagrid. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridQuestions_SelectionChanged(object sender, EventArgs e)
        {
            dataGridQuestions.ClearSelection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   searching the double link list. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int myValue = Convert.ToInt32(textSearch.Text);
            int? Search = listOfNodes.binarySearch(myValue);
            if (Search >= 0)
            {
                textSearch.Text = "Found";
            }
            else
            {
                textSearch.Text = "Not Found";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   sorts the array of questions by ascending by answer to question. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[4], ListSortDirection.Ascending);   
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   sorts the array of questions descending by answer to question. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSort2_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[4], ListSortDirection.Descending);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   prints binary tree pre order to rich text box. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonPreDisplay_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "PRE-ORDER: ";
            richBinaryTree.Text += myTree.printPreOrder(tree: myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   prints binary tree in order to rich text box. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonInDisplay_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "IN-ORDER: ";
            richBinaryTree.Text += myTree.printInOrder(tree: myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   prints binary tree post order to rich text box. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonPostDisplay_Click(object sender, EventArgs e)
        {
            richBinaryTree.Clear();
            richBinaryTree.Text = "POST-ORDER: ";
            richBinaryTree.Text += myTree.printPostOrder(tree: myTree);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   sorts array of questions by operators. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonSort3_Click(object sender, EventArgs e)
        {
            dataGridQuestions.Sort(dataGridQuestions.Columns[1], ListSortDirection.Ascending);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   saves the pre order binary tree to a text file. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonPreSave_Click(object sender, EventArgs e)
        {
            string preOrderPath = "PreOrder.txt";

            using (StreamWriter sw = File.AppendText(preOrderPath))
            {
                sw.WriteLine("PRE-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   saves the in order binary tree to a text file. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonInSave_Click(object sender, EventArgs e)
        {
            string inOrderPath = "InOrder.txt";

            using (StreamWriter sw = File.AppendText(inOrderPath))
            {
                sw.WriteLine("IN-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   saves the post order binary tree to a text file. </summary>
        ///
        /// <remarks>   Parsons, 16-Sep-18. </remarks>
        ///
        /// <param name="sender">   . </param>
        /// <param name="e">        . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonPostSave_Click(object sender, EventArgs e)
        {
            string PostOrderPath = "PostOrder.txt";

            using (StreamWriter sw = File.AppendText(PostOrderPath))
            {
                sw.WriteLine("POST-ORDER: " + myTree.printPreOrder(myTree));
                sw.Close();
            }
        }
    }
}
