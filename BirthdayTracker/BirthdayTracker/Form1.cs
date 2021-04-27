/* 
 *  Student Number: 0105186517
 *  Name:                  Kaitlyn Parsons
 *  Date:                    16/08/2018 
 *  Purpose:              Methods and method calls on buttons to display in the main program.
 *  Known Bugs:       None.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BirthdayTracker
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// csv file path
        /// </summary>
        string path = "MyFriendData.csv";

        /// <summary>
        /// initializes new datatable named dt
        /// </summary>
        DataTable dt = new DataTable();
    
        /// <summary>
        /// index counter    
        /// </summary>
        int Rowindex = 0;

        /// <summary>
        /// default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            WriteFile();
        }

        /// <summary>
        /// this method writes the csv file
        /// </summary>
        public void WriteFile()
        {
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(path, sb.ToString());
        }

        /// <summary>
        /// method displays csv file
        /// </summary>
        public void LoadFile()
        {
            try
            {
                //reads all lines in csv file
                string[] lines = File.ReadAllLines(path);

                //initialize array for fields
                string[] fields;

                //get lines in file and assign to fields
                fields = lines[0].Split(new char[] { ',' });

                //gets length of fields (how many words) and assigns that number to number of columns
                int cols = fields.GetLength(0);

                //iterate through fields and add them to each column
                for (int i = 0; i < cols; i++)
                {
                    dt.Columns.Add(fields[i], typeof(string));
                }

                //initialize datarow
                DataRow row;

                //splits the lines by comma and creates new row
                for (int i = 1; i < lines.GetLength(0); i++)
                {
                    fields = lines[i].Split(new char[] { ',' });
                    row = dt.NewRow();


                    //adds fields to a row
                    for (int f = 0; f < cols; f++)
                    {
                        row[f] = fields[f];
                    }

                    //adds rows to datatable
                    dt.Rows.Add(row);
                }

                //display datatable in dataBirthdays (datagridview)
                dataBirthdays.DataSource = dt;
            }
            catch (Exception err)
            {
                //catch the error and display to user
                MessageBox.Show("Error: \n" + err.ToString());
            }
        }

        /// <summary>
        /// this method sorts the datagridview by the first column
        /// </summary>
        private void sortedTable()
        {
            dataBirthdays.Sort(this.dataBirthdays.Columns["Person"], ListSortDirection.Ascending);
        }

        /// <summary>
        /// this method clears text input fields that relate to adding user information
        /// </summary>
        private void ClearFields()
        {
            textName.Text = "";
            textLikes.Text = "";
            textDislikes.Text = "";
            comboFriendDay.SelectedItem = null;
            comboFriendMonth.SelectedItem = null;
        }

        /// <summary>
        /// this method displays each field in selected row into appropriate text boxes when the row is clicked
        /// </summary>
        /// <param name="e"></param>
        private void displayFriendRow(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dataBirthdays.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                //sets rowindex to the datagridviews rows
                Rowindex = e.RowIndex;
                //gets selected row index
                DataGridViewRow selected = dataBirthdays.Rows[Rowindex];
                //grabs data for selected row with each cells detail
                string name = dataBirthdays.SelectedRows[0].Cells[0].Value + string.Empty;
                string likes = dataBirthdays.SelectedRows[0].Cells[1].Value + string.Empty;
                string dislikes = dataBirthdays.SelectedRows[0].Cells[2].Value + string.Empty;
                string day = dataBirthdays.SelectedRows[0].Cells[3].Value + string.Empty;
                string month = dataBirthdays.SelectedRows[0].Cells[4].Value + string.Empty;

                //displays in textboxes
                textName.Text = name;
                textLikes.Text = likes;
                textDislikes.Text = dislikes;
                comboFriendDay.Text = day;
                comboFriendMonth.Text = month;
            }
        }

        /// <summary>
        /// this method saves a new friends details to the datagridview
        /// </summary>
        private void saveFriendDetails()
        {
            StringBuilder content = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                string name = textName.Text;
                string likes = textLikes.Text;
                string dislikes = textDislikes.Text;
                string day = comboFriendDay.Text;
                string month = comboFriendMonth.Text;
                string[] newFriend = { name, likes, dislikes, day, month };
                dt.Rows.Add(newFriend);
            }
        }

        /// <summary>
        /// deletes friends details from datagrid
        /// </summary>
        private void deletePerson()
        {
            foreach (DataGridViewRow aRow in dataBirthdays.SelectedRows)
            {
                if (!aRow.IsNewRow)
                {
                    dataBirthdays.Rows.Remove(aRow);
                }
            }
        }

        /// <summary>
        /// this method finds friend by their name
        /// </summary>
        private void findFriendByName()
        {
            if (string.IsNullOrEmpty(textFindByName.Text))
            {
                (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Person LIKE '%{0}%'", textFindByName.Text);
            }
        }

        /// <summary>
        /// this method searches for friends by the month they were born
        /// </summary>
        private void searchBirthMonth()
        {
            Rowindex = 0;
            textUpcomingBirthdays.Text = "Birthdays in the month of " + comboMonths.Text;
            int index;
            if (string.IsNullOrEmpty(comboMonths.Text))
            {
                (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                textUpcomingBirthdays.Text = null;
            }
            switch (comboMonths.Text)
            {
                case "January":
                    index = 1;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "February":
                    index = 2;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "March":
                    index = 3;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "April":
                    index = 4;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "May":
                    index = 5;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "June":
                    index = 6;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "July":
                    index = 7;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "August":
                    index = 8;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "September":
                    index = 9;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "October":
                    index = 10;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "November":
                    index = 11;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                case "December":
                    index = 12;
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Format("Month = '{0}'", index);
                    break;
                default:
                    (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    textUpcomingBirthdays.Text = null;
                    break;
            }
        }

        /// <summary>
        /// this method disregards any input into the search fields and shows all the friends in the datagridview
        /// </summary>
        private void showAll()
        {
            Rowindex = 0;
            (dataBirthdays.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            textUpcomingBirthdays.Text = null;
            comboMonths.SelectedItem = null;
            textFindByName.Text = null;
        }

        /// <summary>
        /// this method displays the data of the row from the navigation buttons in the text fields
        /// </summary>
        private void displayFriendOnButtonMovement()
        {
            DataGridViewRow selected = dataBirthdays.Rows[Rowindex];
            //grabs data for selected row with each cells detail
            string name = dataBirthdays.SelectedRows[0].Cells[0].Value + string.Empty;
            string likes = dataBirthdays.SelectedRows[0].Cells[1].Value + string.Empty;
            string dislikes = dataBirthdays.SelectedRows[0].Cells[2].Value + string.Empty;
            string day = dataBirthdays.SelectedRows[0].Cells[3].Value + string.Empty;
            string month = dataBirthdays.SelectedRows[0].Cells[4].Value + string.Empty;

            //displays in textboxes
            textName.Text = name;
            textLikes.Text = likes;
            textDislikes.Text = dislikes;
            comboFriendDay.Text = day;
            comboFriendMonth.Text = month;
        }

        /// <summary>
        /// this method updates the selected friends details
        /// </summary>
        private void updateFriend()
        {
            if (Rowindex != 0)
            {
                DataGridViewRow selected = dataBirthdays.Rows[Rowindex];
                selected.Cells[0].Value = textName.Text;
                selected.Cells[1].Value = textLikes.Text;
                selected.Cells[2].Value = textDislikes.Text;
                selected.Cells[3].Value = comboFriendDay.Text;
                selected.Cells[4].Value = comboFriendMonth.Text;
            }
        }

        /// <summary>
        /// this method prevents the user from entering commas into the details textboxes
        /// </summary>
        /// <param name="e"></param>
        private static void preventCommas(KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// this formLoad calls the loadFile and sortedTable methods. Removes rowpointer and default sorting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFile();
            sortedTable();
            //set Rowindex to the current cell
            Rowindex = dataBirthdays.CurrentCell.RowIndex;
            //For each of the columns in the DataGridView
            foreach (DataGridViewColumn column in dataBirthdays.Columns)
            {
                //Make them not sortable
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //hides the record pointer from the DataGridView
            dataBirthdays.RowHeadersVisible = false;
        }

        /// <summary>
        /// this button finds friend by name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, EventArgs e)
        {
            findFriendByName();
            sortedTable();
        }

        /// <summary>
        /// this cellClick displays the friends details of the row clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataBirthdays_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            displayFriendRow(e);
        }

        /// <summary>
        /// this button clears the fields for ease of entering a new friends details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNew_Click(object sender, EventArgs e)
        {
            sortedTable();
            ClearFields();
            textName.Focus();
        }

        /// <summary>
        /// this button saves new friend to csv file on click, clears text fields and writes it back to the csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ErrorProvider newErr = new ErrorProvider();
            //an if statement to validate the input
            if (string.IsNullOrEmpty(textName.Text) && string.IsNullOrEmpty(textLikes.Text)
                 && string.IsNullOrEmpty(textDislikes.Text) && string.IsNullOrEmpty(comboFriendDay.Text) && string.IsNullOrEmpty(comboFriendMonth.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                saveFriendDetails();
                sortedTable();
                WriteFile();
            }

        }

        /// <summary>
        /// this button updates a selected friends details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //an if statement to validate the input
            if (string.IsNullOrEmpty(textName.Text) || string.IsNullOrEmpty(textLikes.Text) || string.IsNullOrEmpty(textDislikes.Text)
                || string.IsNullOrEmpty(comboFriendDay.Text) || string.IsNullOrEmpty(comboFriendMonth.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                updateFriend();
                sortedTable();
                WriteFile();
            }
        }

        /// <summary>
        /// this button deletes a person from the csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deletePerson();
            ClearFields();
            sortedTable();
            WriteFile();
        }

        /// <summary>
        /// this button returns to first index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFirst_Click(object sender, EventArgs e)
        {
            Rowindex = 0;
            dataBirthdays.Rows[Rowindex].Selected = true;
            dataBirthdays.FirstDisplayedScrollingRowIndex = Rowindex;
            displayFriendOnButtonMovement();
        }

        /// <summary>
        /// this button moves to the last index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLast_Click(object sender, EventArgs e)
        {
            Rowindex = dataBirthdays.Rows.Count - 1;
            dataBirthdays.Rows[Rowindex].Selected = true;
            dataBirthdays.FirstDisplayedScrollingRowIndex = Rowindex;
            displayFriendOnButtonMovement();
        }

        /// <summary>
        /// this button moves to the next index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (Rowindex < dataBirthdays.RowCount - 1)
            {
                dataBirthdays.Rows[++Rowindex].Selected = true;
                dataBirthdays.FirstDisplayedScrollingRowIndex = Rowindex;
                displayFriendOnButtonMovement();
            }
        }

        /// <summary>
        /// this button returns to the previous index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (Rowindex > 0 && Rowindex < dataBirthdays.Rows.Count)
            {
                dataBirthdays.Rows[--Rowindex].Selected = true;
                dataBirthdays.FirstDisplayedScrollingRowIndex = Rowindex;
                displayFriendOnButtonMovement();
            }
        }

        /// <summary>
        /// this button calls the searchBirthMonth and sortedTable methods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchMonth_Click(object sender, EventArgs e)
        {
            searchBirthMonth();
            sortedTable();
        }

        /// <summary>
        /// this button calls the showAll method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            preventCommas(e);
        }

        private void textLikes_KeyPress(object sender, KeyPressEventArgs e)
        {
            preventCommas(e);
        }

        private void textDislikes_KeyPress(object sender, KeyPressEventArgs e)
        {
            preventCommas(e);
        }
    }
}