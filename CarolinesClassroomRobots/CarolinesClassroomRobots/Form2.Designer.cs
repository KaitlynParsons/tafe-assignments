namespace CarolinesClassroomRobots
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridStudentList = new System.Windows.Forms.DataGridView();
            this.Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Across = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Down = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textSearch2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student List - Search: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridStudentList
            // 
            this.dataGridStudentList.AllowUserToAddRows = false;
            this.dataGridStudentList.AllowUserToDeleteRows = false;
            this.dataGridStudentList.AllowUserToResizeColumns = false;
            this.dataGridStudentList.AllowUserToResizeRows = false;
            this.dataGridStudentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridStudentList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridStudentList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridStudentList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridStudentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Student,
            this.Across,
            this.Down});
            this.dataGridStudentList.GridColor = System.Drawing.Color.White;
            this.dataGridStudentList.Location = new System.Drawing.Point(12, 30);
            this.dataGridStudentList.MultiSelect = false;
            this.dataGridStudentList.Name = "dataGridStudentList";
            this.dataGridStudentList.ReadOnly = true;
            this.dataGridStudentList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridStudentList.RowHeadersVisible = false;
            this.dataGridStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridStudentList.Size = new System.Drawing.Size(249, 419);
            this.dataGridStudentList.TabIndex = 1;
            // 
            // Student
            // 
            this.Student.HeaderText = "Student";
            this.Student.Name = "Student";
            this.Student.ReadOnly = true;
            // 
            // Across
            // 
            this.Across.HeaderText = "Across";
            this.Across.Name = "Across";
            this.Across.ReadOnly = true;
            // 
            // Down
            // 
            this.Down.HeaderText = "Down";
            this.Down.Name = "Down";
            this.Down.ReadOnly = true;
            // 
            // textSearch2
            // 
            this.textSearch2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textSearch2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textSearch2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch2.Location = new System.Drawing.Point(154, 10);
            this.textSearch2.Name = "textSearch2";
            this.textSearch2.Size = new System.Drawing.Size(107, 16);
            this.textSearch2.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(273, 461);
            this.Controls.Add(this.textSearch2);
            this.Controls.Add(this.dataGridStudentList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student List";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridStudentList;
        private System.Windows.Forms.TextBox textSearch2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Across;
        private System.Windows.Forms.DataGridViewTextBoxColumn Down;
    }
}