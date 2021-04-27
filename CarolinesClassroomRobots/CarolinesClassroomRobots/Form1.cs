/*
 * Student Number: 450950837
 *  Name:                  Kaitlyn Parsons
 *  Date:                    1/09/2018 
 *  Purpose:              Methods and method calls on buttons to display in the main program.
 *  Known Bugs:       None.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


/// <summary>
/// CarolinesClassroomRobots <see langword="namespace"/>
/// </summary>
namespace CarolinesClassroomRobots
{
    public partial class Form1 : Form
    {
        //to send to form2
        public static string sendText = "";
        //path to csv file/s
        private string pathToFile = "";
        //List to write to csv
        List<string> stringVal = new List<string>();
        //list to store student names for binary search
        List<string> studentNames = new List<string>();
        //ArrayList to hold all lines of the file
        ArrayList fields = new ArrayList();
        //row and column indexers for context menu
        private int rowIndex;
        private int columnIndex;
        //array for student names
        string[] array;
        //for adding just the student names to the studentName list
        string value;
        //for RAF 
        static int pos = 0;
        int RecSize { get; set; } = 30;
        /// <summary>
        /// default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Text = DateTime.Today.ToString("dd/MM/yyyy");
            disableButtons();
        }

        /// <summary>
        /// disables the sort and find buttons until a csv file is opened
        /// </summary>
        private void disableButtons()
        {
            if (pathToFile == "")
            {
                buttonSort.Enabled = false;
                buttonFind.Enabled = false;
                buttonRAF.Enabled = false;
            }
            else
            {
                buttonSort.Enabled = true;
                buttonFind.Enabled = true;
                buttonRAF.Enabled = true;
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// reads a Random Access File
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRAF_Click(object sender, EventArgs e)
        {
            //clear the list to avoid double ups
            studentNames.Clear();
            stringVal.Clear();
            try
            {
                readFromFile("Student.txt");
                addStudentNamesToList();
                addClassroomToList();
                addrecord();
                int value;
                bool parseSuccess = int.TryParse(textSearch.Text, out value);
                if (parseSuccess == false)
                {
                    MessageBox.Show("Please enter a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (value == 0)
                {
                    MessageBox.Show("Please enter a number greater than 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (value > studentNames.Count)
                {
                    MessageBox.Show("Please enter a number less than " + studentNames.Count.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    findFromFile("Student.txt", Convert.ToInt32(textSearch.Text));
                    Form2 passData = new Form2(stringVal);
                    //show form2
                    passData.Show();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// this method creates an opens a file dialog of only csv files
        /// </summary>
        private void openFileDialog()
        {
            //creates a new openfiledialog
            OpenFileDialog openFile = new OpenFileDialog();

            //filter so you can only open csv files 
            openFile.Filter = "CSV files (*.csv)|*.csv";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //opens the file
                clearDetails();
                clearStudents();
                pathToFile = openFile.FileName;
                displayAllData();
            }
        }

        /// <summary>
        /// Saves current as csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog();
        }

        /// <summary>
        /// this method creates a save file dialog of a csv file
        /// </summary>
        private void saveFileDialog()
        {
            //create a new savefiledialog
            SaveFileDialog saveFile = new SaveFileDialog();

            //filter so you can only save as a csv
            saveFile.Filter = "CSV files (*.csv)|*.csv";

            //show  the save dialog
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string name = saveFile.FileName;
                addClassroomToList();
                var str = string.Join(",", stringVal.Select(x => string.Join(",", x)));
                File.WriteAllText(name, str);
            }
        }

        /// <summary>
        /// this method conducts a binary search on the students names once they're added to the list and sorted
        /// </summary>
        private void binarySearch()
        {
            sendText = null;
            addStudentNamesToList();
            //do a binary search on the array
            int index = Array.BinarySearch(array, textSearch.Text, StringComparer.OrdinalIgnoreCase);
            sendText = textSearch.Text;
            Form2 passData = new Form2(stringVal);
            if (index >= 0)
            {
                //the int returned from the search is the location of where the student is in the sorted list (popup)
                MessageBox.Show(textSearch.Text + " can be found at index " + index.ToString() + " in the student list.", "Binary Search");
                passData.Show();
            }
            else
            {
                MessageBox.Show("No student can be found with that name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passData.Hide();
            }
        }

        /// <summary>
        /// Write to Random Access File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        static void writeToFile(string filename, Student obj, int pos, int size)
        {
            FileStream fout;
            BinaryWriter bw;
            //create a file stream object
            fout = new FileStream(filename, FileMode.Append, FileAccess.Write);
            //create a binary writer object
            bw = new BinaryWriter(fout);
            //set file position where to write data
            fout.Position = pos * size;
            //write data
            bw.Write(obj.stunumber);
            bw.Write(obj.stuname);
            //close objects
            bw.Close();
            fout.Close();
        }

        /// <summary>
        /// reads from Random Access File
        /// </summary>
        /// <param name="filename"></param>
        static void readFromFile(string filename)
        {
            FileStream fn;
            BinaryReader br;
            Student stu = new Student();
            int currentrecord = 0;
            //open file to read data
            try
            {
                File.Create(filename).Dispose();
                fn = new FileStream(filename, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fn);
                //read next record
                int i;
                for (i = 1; i <= (int)(fn.Length) / stu.size; i++)
                {
                    currentrecord += 1; //update currentrecord position
                    fn.Seek(currentrecord * stu.size, 0);
                    stu.stunumber = br.ReadString().ToString();
                    stu.stuname = br.ReadString().ToString();
                    MessageBox.Show(stu.stunumber + ", " + stu.stuname);
                }
                //update pos to the current position
                pos = currentrecord;
                //close objects
                br.Close();
                fn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// add student list to Random Access File
        /// </summary>
        public void addrecord()
        {
            Student stu = new Student();
            foreach (var item in array)
            {
                stu.stunumber = pos.ToString();
                stu.stuname = item.ToString();
                pos++;
                writeToFile("Student.txt", stu, pos, stu.size);
            }

        }

        /// <summary>
        /// finds index in Random Access File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="index"></param>
        public void findFromFile(string filename, int index)
        {
            FileStream fn;
            BinaryReader br;
            Student stu = new Student();
            int currentrecord = index;

            //open file to read data
            try
            {
                fn = new FileStream(filename, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fn);
                //read indexed record
                //update currentrecord position
                currentrecord = index;
                fn.Seek(currentrecord * stu.size, 0);
                stu.stunumber = br.ReadString().ToString();
                stu.stuname = br.ReadString().ToString();
                sendText = stu.stuname.ToString();
                MessageBox.Show("Record " + textSearch.Text + " in the Student List is: " + stu.stunumber + ", " + stu.stuname, "Random Access File Search");
                //close objects
                br.Close();
                fn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// adds the student names to a list
        /// </summary>
        private void addStudentNamesToList()
        {
            foreach (DataGridViewRow row in dataGridClassroom.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString() != "" && cell.Value.ToString() != null && cell.Value.ToString() != "BKGRND FILL" && cell.Value.ToString() != "Front Desk")
                    {
                        value = cell.Value.ToString();
                        studentNames.Add(value);
                    }
                }
            }
            //convert the list to an array 
            array = studentNames.ToArray();
            //sort the array of students
            Array.Sort(array);
        }

        /// <summary>
        /// adds the classroom to a list
        /// </summary>
        private void addClassroomToList()
        {
            classroomDetails();
            foreach (DataGridViewRow row in dataGridClassroom.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        if (cell.Value.ToString() != "" && cell.Value != null)
                        {
                            string rowNum = cell.RowIndex.ToString();
                            int rowInt = cell.RowIndex;
                            string colNum = cell.ColumnIndex.ToString();
                            int colInt = cell.ColumnIndex;
                            string value = cell.Value.ToString();
                            string grid = colNum + "," + rowNum + "," + value + Environment.NewLine;
                            //add the grid to the list
                            stringVal.Add(grid);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot sort an empty classroom");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// adds the classroom details to a list
        /// </summary>
        private void classroomDetails()
        {
            string Teacher = "Teacher:" + "," + textTeacher.Text + Environment.NewLine;
            string Class = "Class:" + "," + textClass.Text + Environment.NewLine;
            string Room = "Room:" + "," + textRoom.Text + Environment.NewLine;
            string Date = "Date:" + "," + dateTimePicker1.Text + Environment.NewLine;
            string classroom = Teacher + Class + Room + Date;
            stringVal.Add(classroom);
        }

        /// <summary>
        /// Finds user entered name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, EventArgs e)
        {
            studentNames.Clear();
            binarySearch();
            search();
        }

        /// <summary>
        /// searches the datagrid for a student and highlights their cell, opens student list and highlights row
        /// </summary>
        private void search()
        {
            string searchValue = textSearch.Text;
            //if searchValue is empty
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a student name.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                hightlightCell(searchValue);
                stringVal.Clear();
                addClassroomToList();
            }
        }

        /// <summary>
        /// this method hightlights a cell in the datagridview depending on the search value
        /// </summary>
        /// <param name="searchValue"></param>
        private void hightlightCell(string searchValue)
        {
            foreach (DataGridViewRow row in dataGridClassroom.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) { continue; }
                    if (cell.Value.ToString().Equals(searchValue, StringComparison.CurrentCultureIgnoreCase) && cell.Value.ToString() != null)
                    {
                        int r = cell.RowIndex;
                        int c = cell.ColumnIndex;
                        var cellSelect = dataGridClassroom.Rows[r].Cells[c];
                        dataGridClassroom.CurrentCell = cellSelect;
                    }
                }
            }
        }

        /// <summary>
        /// gets the cell values and locations of datagrid, displays them in a new form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            //clear the list to avoid double ups
            stringVal.Clear();
            sendText = null;
            addClassroomToList();
            //pass the list to form2
            Form2 passData = new Form2(stringVal);
            //show form2
            passData.Show();

        }

        /// <summary>
        /// clears the grid and textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //confirm that they would like to clear the classroom
            if (MessageBox.Show("Are you sure you want to clear the classroom?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //clear the classroom
                clearStudents();
            }
            disableButtons();
        }

        /// <summary>
        /// clears the classroom details and grid
        /// </summary>
        private void clearStudents()
        {
            dataGridClassroom.CurrentCell = null;
            pathToFile = "";
            //clear the arrayList to allow for population of a new csv file
            fields.Clear();
            for (int i = 0; i < dataGridClassroom.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridClassroom.Rows.Count; j++)
                {
                        dataGridClassroom.Rows[j].Cells[i].Value = "";
                        dataGridClassroom.Rows[j].Cells[i].Style.BackColor = Color.Empty;
                        dataGridClassroom.Rows[j].Cells[i].Style.ForeColor = Color.Empty;
                }
            }
            dataGridClassroom.Refresh();
        }

        /// <summary>
        /// clear classroom details and set date picker to current date
        /// </summary>
        private void clearDetails()
        {
            textTeacher.Text = null;
            textClass.Text = null;
            textRoom.Text = null;
            textSearch.Text = null;
            dateTimePicker1.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// sets the row header cell to display row number starting from 0
        /// </summary>
        /// <param name="dgv"></param>
        private void setRowNumber(DataGridView dgv)
        {
            int rowNum = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = (rowNum).ToString();
                rowNum = rowNum + 1;
            }
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        /// <summary>
        /// add rows to the datagrid when form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridClassroom.Rows.Add(19);
            setRowNumber(dataGridClassroom);

            //For each of the columns in the DataGridView
            foreach (DataGridViewColumn column in dataGridClassroom.Columns)
            {
                //Make them not sortable
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// display all the data for the classroom in the textboxes and grid
        /// </summary>
        private void displayAllData()
        {
            //open the data file
            StreamReader sr = new StreamReader(new FileStream(pathToFile, FileMode.Open));

            string curLine;
            //read in the data line by line and add it to our ArrayList
            while ((curLine = sr.ReadLine()) != null)
            {
                fields.Add(curLine);
            }

            //close the streamreader
            sr.Close();
            //display teacher, class, room, date and populate grid
            displayLine(0);
            displayLine(1);
            displayLine(2);
            displayLine(3);
            populateGrid(pathToFile);
        }

        /// <summary>
        /// populates the grid depending on file path
        /// </summary>
        /// <param name="path"></param>
        private void populateGrid(string path)
        {
            //reads all lines in csv file
            string[] lines = File.ReadAllLines(path);
            //counter for the lines in csv
            int lineNum = 4;
            try
            {
                //foreach to iterate through lines in csv
                foreach (var line in lines)
                {
                    while (lineNum < lines.Length)
                    {
                        //get the string out of the arrayList
                        string field = (string)fields[lineNum];
                        //split it into various pieces on the space
                        string[] pieces = field.Split(',');
                        //gets col index
                        int col = Convert.ToInt32(pieces[1]);
                        //gets row index
                        int row = Convert.ToInt32(pieces[2]);
                        //prints value to datagrid
                        dataGridClassroom.Rows[row].Cells[col].Value = pieces[3].ToString();
                        //increment by 1
                        lineNum++;
                        //iterate through rows
                        for (int i = 0; i < dataGridClassroom.Rows.Count; i++)
                        {
                            if (dataGridClassroom.Rows[row].Displayed)
                            {
                                //check if value contains BKGRND FILL
                                if (dataGridClassroom.Rows[row].Cells[col].Value.ToString().Contains("BKGRND FILL"))
                                {
                                    //change back colour
                                    this.dataGridClassroom.Rows[row].Cells[col].Style.BackColor = Color.LightBlue;
                                    //change fore colour
                                    this.dataGridClassroom.Rows[row].Cells[col].Style.ForeColor = Color.LightBlue;
                                    this.dataGridClassroom.InvalidateRow(i);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong!\n" + e);
            }
        }

        /// <summary>
        /// display the line in the arrayList
        /// </summary>
        /// <param name="lineNum"></param>
        private void displayLine(int lineNum)
        {
            //If the line number is in the range of total values
            if (lineNum >= 0 && lineNum < fields.Count)
            {
                //get the string out of the arrayList
                string line = (string)fields[lineNum];
                //split it into various pieces on the space
                string[] pieces = line.Split(',');
                //populate the text boxes with the appropriate pieces
                if (lineNum == 0)
                {
                    textTeacher.Text = pieces[1];
                }
                if (lineNum == 1)
                {
                    textClass.Text = pieces[1];
                }
                if (lineNum == 2)
                {
                    textRoom.Text = pieces[1];
                }
                if (lineNum == 3)
                {
                    dateTimePicker1.Text = pieces[1];
                }
            }
        }

        /// <summary>
        /// when right mouse button is clicked shows context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridClassroom_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();

                rowIndex = dataGridClassroom.HitTest(e.X, e.Y).RowIndex;
                columnIndex = dataGridClassroom.HitTest(e.X, e.Y).ColumnIndex;
                if (rowIndex != -1 && columnIndex != -1)
                {
                    dataGridClassroom.CurrentCell = dataGridClassroom.Rows[rowIndex].Cells[columnIndex];
                }
                else
                {
                    return;
                }

                MenuItem editCell = new MenuItem("Edit Cell");
                MenuItem clearCell = new MenuItem("Clear Cell");
                MenuItem addDesk = new MenuItem("Set as Desk");
                MenuItem removeDesk = new MenuItem("Unset Desk");

                menu.MenuItems.Add(editCell);
                menu.MenuItems.Add(clearCell);
                menu.MenuItems.Add(addDesk);

                editCell.Click += EditCell_Click;
                clearCell.Click += ClearCell_Click;
                addDesk.Click += AddDesk_Click;

                menu.Show(dataGridClassroom, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// sets a cell to a desk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDesk_Click(object sender, EventArgs e)
        {
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.LightBlue;
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.LightBlue;
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Value = "BKGRND FILL";
        }

        /// <summary>
        /// clears the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCell_Click(object sender, EventArgs e)
        {
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.White;
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Value = "";
        }

        /// <summary>
        /// edit the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCell_Click(object sender, EventArgs e)
        {
            dataGridClassroom.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.Black;
            dataGridClassroom.BeginEdit(true);
        }

        /// <summary>
        /// Opens a csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog();
            disableButtons();
            studentNames.Clear();
        }
    }
}
