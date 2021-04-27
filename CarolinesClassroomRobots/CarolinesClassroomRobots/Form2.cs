/*
 * Student Number: 450950837
 *  Name:                  Kaitlyn Parsons
 *  Date:                    2/09/2018 
 *  Purpose:              Display the student list
 *  Known Bugs:       None.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarolinesClassroomRobots
{
    public partial class Form2 : Form
    {
        //list to pass data to from form1
        List<string> students = new List<string>();
        /// <summary>
        /// default constructor
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// constructor with list
        /// </summary>
        /// <param name="stringList"></param>
        public Form2(List<string> stringList)
        {
            InitializeComponent();
            textSearch2.Text = Form1.sendText;
            students = stringList;
        }

        /// <summary>
        /// when the form loads, calls addListToDataGrid method and sets heads to blue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            textSearch2.Text = Form1.sendText;
            addListToDataGrid();
            dataGridStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridStudentList.EnableHeadersVisualStyles = false;
            //For each of the columns in the DataGridView
            foreach (DataGridViewColumn column in dataGridStudentList.Columns)
            {
                //Make them not sortable
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// adds the list to the grid
        /// </summary>
        private void addListToDataGrid()
        {
            string searchValue = textSearch2.Text;
            string[] fields;
            foreach (var item in students.Skip(3))
            {
                fields = item.Split(',');
                if (item != null && !item.ToString().Contains("BKGRND FILL"))
                {
                    dataGridStudentList.Rows.Add(fields[2].ToString(), fields[0].ToString(), fields[1].ToString());
                    this.dataGridStudentList.Sort(this.dataGridStudentList.Columns[0], ListSortDirection.Ascending);
                }
            }
            highlightRow(searchValue);
        }

        /// <summary>
        /// highlights the given row
        /// </summary>
        /// <param name="searchValue"></param>
        private void highlightRow(string searchValue)
        {
            foreach (DataGridViewRow row in dataGridStudentList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) { continue; }
                    if (cell.Value.ToString().ToLower().Contains(searchValue.ToLower()))
                    {
                        int r = cell.RowIndex;
                        int c = cell.ColumnIndex;
                        var cellSelect = dataGridStudentList.Rows[r].Cells[c];
                        dataGridStudentList.CurrentCell = cellSelect;
                        return;
                    }
                }
            }
        }
    }
}
