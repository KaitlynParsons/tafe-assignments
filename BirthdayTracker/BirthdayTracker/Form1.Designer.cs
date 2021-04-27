namespace BirthdayTracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textLikes = new System.Windows.Forms.TextBox();
            this.textDislikes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.textFindByName = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSearchMonth = new System.Windows.Forms.Button();
            this.dataBirthdays = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboFriendDay = new System.Windows.Forms.ComboBox();
            this.comboFriendMonth = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboMonths = new System.Windows.Forms.ComboBox();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textUpcomingBirthdays = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataBirthdays)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Birthday Tracker";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Indigo;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Person\'s Name:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(138, 3);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(166, 20);
            this.textName.TabIndex = 2;
            this.textName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textName_KeyPress);
            // 
            // textLikes
            // 
            this.textLikes.Location = new System.Drawing.Point(138, 29);
            this.textLikes.Name = "textLikes";
            this.textLikes.Size = new System.Drawing.Size(166, 20);
            this.textLikes.TabIndex = 3;
            this.textLikes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLikes_KeyPress);
            // 
            // textDislikes
            // 
            this.textDislikes.Location = new System.Drawing.Point(138, 55);
            this.textDislikes.Name = "textDislikes";
            this.textDislikes.Size = new System.Drawing.Size(166, 20);
            this.textDislikes.TabIndex = 4;
            this.textDislikes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDislikes_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Indigo;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Likes:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Indigo;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dislikes:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Indigo;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "B/Day Day:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Indigo;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "B/Day Month:";
            // 
            // buttonFirst
            // 
            this.buttonFirst.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFirst.Location = new System.Drawing.Point(2, 259);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(61, 25);
            this.buttonFirst.TabIndex = 11;
            this.buttonFirst.Text = "|< First";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.Location = new System.Drawing.Point(69, 259);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(87, 25);
            this.buttonPrevious.TabIndex = 12;
            this.buttonPrevious.Text = "< Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(381, 259);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(55, 25);
            this.buttonNext.TabIndex = 13;
            this.buttonNext.Text = "Next > ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLast.Location = new System.Drawing.Point(442, 259);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(61, 25);
            this.buttonLast.TabIndex = 14;
            this.buttonLast.Text = "Last >|";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // textFindByName
            // 
            this.textFindByName.Location = new System.Drawing.Point(3, 5);
            this.textFindByName.Name = "textFindByName";
            this.textFindByName.Size = new System.Drawing.Size(152, 20);
            this.textFindByName.TabIndex = 16;
            // 
            // buttonFind
            // 
            this.buttonFind.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.Location = new System.Drawing.Point(2, 30);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(153, 23);
            this.buttonFind.TabIndex = 17;
            this.buttonFind.Text = "Find By Name";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.Location = new System.Drawing.Point(6, 131);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(70, 23);
            this.buttonNew.TabIndex = 18;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(82, 131);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 23);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(234, 131);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(70, 23);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Indigo;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(-1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(508, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Birthday List:";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(6, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(298, 23);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSearchMonth
            // 
            this.buttonSearchMonth.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchMonth.Location = new System.Drawing.Point(161, 30);
            this.buttonSearchMonth.Name = "buttonSearchMonth";
            this.buttonSearchMonth.Size = new System.Drawing.Size(143, 23);
            this.buttonSearchMonth.TabIndex = 25;
            this.buttonSearchMonth.Text = "Search Month";
            this.buttonSearchMonth.UseVisualStyleBackColor = true;
            this.buttonSearchMonth.Click += new System.EventHandler(this.buttonSearchMonth_Click);
            // 
            // dataBirthdays
            // 
            this.dataBirthdays.AllowUserToAddRows = false;
            this.dataBirthdays.AllowUserToDeleteRows = false;
            this.dataBirthdays.AllowUserToResizeColumns = false;
            this.dataBirthdays.AllowUserToResizeRows = false;
            this.dataBirthdays.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataBirthdays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataBirthdays.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataBirthdays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBirthdays.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataBirthdays.Location = new System.Drawing.Point(2, 20);
            this.dataBirthdays.MultiSelect = false;
            this.dataBirthdays.Name = "dataBirthdays";
            this.dataBirthdays.ReadOnly = true;
            this.dataBirthdays.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataBirthdays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBirthdays.Size = new System.Drawing.Size(502, 233);
            this.dataBirthdays.TabIndex = 27;
            this.dataBirthdays.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBirthdays_CellClick);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(158, 131);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(70, 23);
            this.buttonUpdate.TabIndex = 29;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboFriendDay);
            this.panel1.Controls.Add(this.comboFriendMonth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textName);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Controls.Add(this.textLikes);
            this.panel1.Controls.Add(this.textDislikes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonNew);
            this.panel1.Location = new System.Drawing.Point(11, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 163);
            this.panel1.TabIndex = 31;
            // 
            // comboFriendDay
            // 
            this.comboFriendDay.DropDownHeight = 100;
            this.comboFriendDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFriendDay.DropDownWidth = 65;
            this.comboFriendDay.FormattingEnabled = true;
            this.comboFriendDay.IntegralHeight = false;
            this.comboFriendDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboFriendDay.Location = new System.Drawing.Point(138, 81);
            this.comboFriendDay.Name = "comboFriendDay";
            this.comboFriendDay.Size = new System.Drawing.Size(65, 21);
            this.comboFriendDay.TabIndex = 34;
            // 
            // comboFriendMonth
            // 
            this.comboFriendMonth.DropDownHeight = 100;
            this.comboFriendMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFriendMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFriendMonth.FormattingEnabled = true;
            this.comboFriendMonth.IntegralHeight = false;
            this.comboFriendMonth.ItemHeight = 13;
            this.comboFriendMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboFriendMonth.Location = new System.Drawing.Point(138, 107);
            this.comboFriendMonth.Name = "comboFriendMonth";
            this.comboFriendMonth.Size = new System.Drawing.Size(65, 21);
            this.comboFriendMonth.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboMonths);
            this.panel2.Controls.Add(this.buttonShowAll);
            this.panel2.Controls.Add(this.textFindByName);
            this.panel2.Controls.Add(this.buttonFind);
            this.panel2.Controls.Add(this.buttonSearchMonth);
            this.panel2.Location = new System.Drawing.Point(12, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 85);
            this.panel2.TabIndex = 32;
            // 
            // comboMonths
            // 
            this.comboMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonths.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMonths.FormattingEnabled = true;
            this.comboMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboMonths.Location = new System.Drawing.Point(161, 3);
            this.comboMonths.Name = "comboMonths";
            this.comboMonths.Size = new System.Drawing.Size(142, 24);
            this.comboMonths.TabIndex = 34;
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowAll.Location = new System.Drawing.Point(3, 57);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(300, 23);
            this.buttonShowAll.TabIndex = 27;
            this.buttonShowAll.Text = "Display All Friends";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textUpcomingBirthdays);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.buttonFirst);
            this.panel3.Controls.Add(this.buttonPrevious);
            this.panel3.Controls.Add(this.buttonNext);
            this.panel3.Controls.Add(this.dataBirthdays);
            this.panel3.Controls.Add(this.buttonLast);
            this.panel3.Location = new System.Drawing.Point(326, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 288);
            this.panel3.TabIndex = 33;
            // 
            // textUpcomingBirthdays
            // 
            this.textUpcomingBirthdays.BackColor = System.Drawing.Color.Indigo;
            this.textUpcomingBirthdays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUpcomingBirthdays.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUpcomingBirthdays.ForeColor = System.Drawing.Color.White;
            this.textUpcomingBirthdays.Location = new System.Drawing.Point(141, -1);
            this.textUpcomingBirthdays.Name = "textUpcomingBirthdays";
            this.textUpcomingBirthdays.Size = new System.Drawing.Size(246, 16);
            this.textUpcomingBirthdays.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonExit);
            this.panel4.Location = new System.Drawing.Point(11, 282);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(309, 31);
            this.panel4.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(845, 323);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birthday Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBirthdays)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textLikes;
        private System.Windows.Forms.TextBox textDislikes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.TextBox textFindByName;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSearchMonth;
        private System.Windows.Forms.DataGridView dataBirthdays;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.TextBox textUpcomingBirthdays;
        private System.Windows.Forms.ComboBox comboMonths;
        private System.Windows.Forms.ComboBox comboFriendMonth;
        private System.Windows.Forms.ComboBox comboFriendDay;
        private System.Windows.Forms.Panel panel4;
    }
}

