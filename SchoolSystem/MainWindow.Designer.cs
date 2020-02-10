namespace SchoolSystem
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.labelMenuStudents = new System.Windows.Forms.Label();
            this.labelMenuLectures = new System.Windows.Forms.Label();
            this.labelMenuCourses = new System.Windows.Forms.Label();
            this.labelMenuResources = new System.Windows.Forms.Label();
            this.labelMenuGrades = new System.Windows.Forms.Label();
            this.labelMenuPayments = new System.Windows.Forms.Label();
            this.labelMenuRooms = new System.Windows.Forms.Label();
            this.groupBoxStudents = new System.Windows.Forms.GroupBox();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClearFields = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxDOB = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxIdNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelIDNumber = new System.Windows.Forms.Label();
            this.groupBoxStudents.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMenuStudents
            // 
            this.labelMenuStudents.AutoSize = true;
            this.labelMenuStudents.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuStudents.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuStudents.Location = new System.Drawing.Point(12, 9);
            this.labelMenuStudents.Name = "labelMenuStudents";
            this.labelMenuStudents.Size = new System.Drawing.Size(127, 33);
            this.labelMenuStudents.TabIndex = 0;
            this.labelMenuStudents.Text = "Students";
            this.labelMenuStudents.Click += new System.EventHandler(this.labelMenuStudents_Click);
            this.labelMenuStudents.MouseLeave += new System.EventHandler(this.labelMenuStudents_MouseLeave);
            this.labelMenuStudents.MouseHover += new System.EventHandler(this.labelMenuStudents_MouseHover);
            // 
            // labelMenuLectures
            // 
            this.labelMenuLectures.AutoSize = true;
            this.labelMenuLectures.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuLectures.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuLectures.Location = new System.Drawing.Point(145, 9);
            this.labelMenuLectures.Name = "labelMenuLectures";
            this.labelMenuLectures.Size = new System.Drawing.Size(124, 33);
            this.labelMenuLectures.TabIndex = 0;
            this.labelMenuLectures.Text = "Lectures";
            this.labelMenuLectures.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuLectures_MouseClick);
            this.labelMenuLectures.MouseLeave += new System.EventHandler(this.labelMenuLectures_MouseLeave);
            this.labelMenuLectures.MouseHover += new System.EventHandler(this.labelMenuLectures_MouseHover);
            // 
            // labelMenuCourses
            // 
            this.labelMenuCourses.AutoSize = true;
            this.labelMenuCourses.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuCourses.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuCourses.Location = new System.Drawing.Point(275, 9);
            this.labelMenuCourses.Name = "labelMenuCourses";
            this.labelMenuCourses.Size = new System.Drawing.Size(117, 33);
            this.labelMenuCourses.TabIndex = 0;
            this.labelMenuCourses.Text = "Courses";
            this.labelMenuCourses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuCourses_MouseClick);
            this.labelMenuCourses.MouseLeave += new System.EventHandler(this.labelMenuCourses_MouseLeave);
            this.labelMenuCourses.MouseHover += new System.EventHandler(this.labelMenuCourses_MouseHover);
            // 
            // labelMenuResources
            // 
            this.labelMenuResources.AutoSize = true;
            this.labelMenuResources.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuResources.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuResources.Location = new System.Drawing.Point(507, 9);
            this.labelMenuResources.Name = "labelMenuResources";
            this.labelMenuResources.Size = new System.Drawing.Size(146, 33);
            this.labelMenuResources.TabIndex = 0;
            this.labelMenuResources.Text = "Resources";
            this.labelMenuResources.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuResources_MouseClick);
            this.labelMenuResources.MouseLeave += new System.EventHandler(this.labelMenuResources_MouseLeave);
            this.labelMenuResources.MouseHover += new System.EventHandler(this.labelMenuResources_MouseHover);
            // 
            // labelMenuGrades
            // 
            this.labelMenuGrades.AutoSize = true;
            this.labelMenuGrades.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuGrades.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuGrades.Location = new System.Drawing.Point(760, 9);
            this.labelMenuGrades.Name = "labelMenuGrades";
            this.labelMenuGrades.Size = new System.Drawing.Size(112, 33);
            this.labelMenuGrades.TabIndex = 0;
            this.labelMenuGrades.Text = "Grades";
            this.labelMenuGrades.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuGrades_MouseClick);
            this.labelMenuGrades.MouseLeave += new System.EventHandler(this.labelMenuGrades_MouseLeave);
            this.labelMenuGrades.MouseHover += new System.EventHandler(this.labelMenuGrades_MouseHover);
            // 
            // labelMenuPayments
            // 
            this.labelMenuPayments.AutoSize = true;
            this.labelMenuPayments.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuPayments.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuPayments.Location = new System.Drawing.Point(878, 9);
            this.labelMenuPayments.Name = "labelMenuPayments";
            this.labelMenuPayments.Size = new System.Drawing.Size(144, 33);
            this.labelMenuPayments.TabIndex = 0;
            this.labelMenuPayments.Text = "Payments";
            this.labelMenuPayments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuPayments_MouseClick);
            this.labelMenuPayments.MouseLeave += new System.EventHandler(this.labelMenuPayments_MouseLeave);
            this.labelMenuPayments.MouseHover += new System.EventHandler(this.labelMenuPayments_MouseHover);
            // 
            // labelMenuRooms
            // 
            this.labelMenuRooms.AutoSize = true;
            this.labelMenuRooms.BackColor = System.Drawing.Color.Transparent;
            this.labelMenuRooms.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuRooms.Location = new System.Drawing.Point(398, 9);
            this.labelMenuRooms.Name = "labelMenuRooms";
            this.labelMenuRooms.Size = new System.Drawing.Size(103, 33);
            this.labelMenuRooms.TabIndex = 0;
            this.labelMenuRooms.Text = "Rooms";
            this.labelMenuRooms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMenuRooms_MouseClick);
            this.labelMenuRooms.MouseLeave += new System.EventHandler(this.labelMenuRooms_MouseLeave);
            this.labelMenuRooms.MouseHover += new System.EventHandler(this.labelMenuRooms_MouseHover);
            // 
            // groupBoxStudents
            // 
            this.groupBoxStudents.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxStudents.Controls.Add(this.buttonAddStudent);
            this.groupBoxStudents.Controls.Add(this.buttonDelete);
            this.groupBoxStudents.Controls.Add(this.buttonClearFields);
            this.groupBoxStudents.Controls.Add(this.buttonUpdate);
            this.groupBoxStudents.Controls.Add(this.buttonLast);
            this.groupBoxStudents.Controls.Add(this.buttonLoadData);
            this.groupBoxStudents.Controls.Add(this.buttonFirst);
            this.groupBoxStudents.Controls.Add(this.buttonNext);
            this.groupBoxStudents.Controls.Add(this.buttonPrevious);
            this.groupBoxStudents.Controls.Add(this.buttonSearch);
            this.groupBoxStudents.Controls.Add(this.comboBoxCourse);
            this.groupBoxStudents.Controls.Add(this.textBoxAddress);
            this.groupBoxStudents.Controls.Add(this.textBoxDOB);
            this.groupBoxStudents.Controls.Add(this.textBoxName);
            this.groupBoxStudents.Controls.Add(this.textBoxIdNumber);
            this.groupBoxStudents.Controls.Add(this.label1);
            this.groupBoxStudents.Controls.Add(this.labelCourse);
            this.groupBoxStudents.Controls.Add(this.labelAddress);
            this.groupBoxStudents.Controls.Add(this.labelDateOfBirth);
            this.groupBoxStudents.Controls.Add(this.labelName);
            this.groupBoxStudents.Controls.Add(this.labelIDNumber);
            this.groupBoxStudents.Location = new System.Drawing.Point(18, 64);
            this.groupBoxStudents.Name = "groupBoxStudents";
            this.groupBoxStudents.Size = new System.Drawing.Size(1004, 443);
            this.groupBoxStudents.TabIndex = 1;
            this.groupBoxStudents.TabStop = false;
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddStudent.Location = new System.Drawing.Point(796, 370);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(167, 48);
            this.buttonAddStudent.TabIndex = 19;
            this.buttonAddStudent.Text = "Add Student";
            this.buttonAddStudent.UseVisualStyleBackColor = true;
            this.buttonAddStudent.Click += new System.EventHandler(this.buttonAddStudent_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(404, 370);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(167, 48);
            this.buttonDelete.TabIndex = 18;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClearFields
            // 
            this.buttonClearFields.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearFields.Location = new System.Drawing.Point(21, 370);
            this.buttonClearFields.Name = "buttonClearFields";
            this.buttonClearFields.Size = new System.Drawing.Size(167, 48);
            this.buttonClearFields.TabIndex = 17;
            this.buttonClearFields.Text = "Clear Fields";
            this.buttonClearFields.UseVisualStyleBackColor = true;
            this.buttonClearFields.Click += new System.EventHandler(this.buttonClearFields_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(600, 370);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(167, 48);
            this.buttonUpdate.TabIndex = 16;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLast.Location = new System.Drawing.Point(656, 286);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(93, 48);
            this.buttonLast.TabIndex = 15;
            this.buttonLast.Text = "Last";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadData.Location = new System.Drawing.Point(780, 48);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(218, 72);
            this.buttonLoadData.TabIndex = 14;
            this.buttonLoadData.Text = "Load Data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFirst.Location = new System.Drawing.Point(263, 286);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(93, 48);
            this.buttonFirst.TabIndex = 13;
            this.buttonFirst.Text = "First";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(522, 286);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(93, 48);
            this.buttonNext.TabIndex = 12;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.Location = new System.Drawing.Point(386, 286);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(104, 48);
            this.buttonPrevious.TabIndex = 11;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(216, 370);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(167, 48);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(263, 240);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(486, 32);
            this.comboBoxCourse.TabIndex = 9;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(263, 192);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(486, 29);
            this.textBoxAddress.TabIndex = 4;
            // 
            // textBoxDOB
            // 
            this.textBoxDOB.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDOB.Location = new System.Drawing.Point(263, 139);
            this.textBoxDOB.Multiline = true;
            this.textBoxDOB.Name = "textBoxDOB";
            this.textBoxDOB.Size = new System.Drawing.Size(486, 29);
            this.textBoxDOB.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(263, 93);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(486, 29);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxIdNumber
            // 
            this.textBoxIdNumber.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdNumber.Location = new System.Drawing.Point(263, 48);
            this.textBoxIdNumber.Multiline = true;
            this.textBoxIdNumber.Name = "textBoxIdNumber";
            this.textBoxIdNumber.Size = new System.Drawing.Size(486, 29);
            this.textBoxIdNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 0;
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.BackColor = System.Drawing.Color.Transparent;
            this.labelCourse.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourse.Location = new System.Drawing.Point(17, 248);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(82, 24);
            this.labelCourse.TabIndex = 0;
            this.labelCourse.Text = "Course";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelAddress.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(17, 195);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(89, 24);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Address";
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.BackColor = System.Drawing.Color.Transparent;
            this.labelDateOfBirth.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateOfBirth.Location = new System.Drawing.Point(17, 144);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(227, 24);
            this.labelDateOfBirth.TabIndex = 0;
            this.labelDateOfBirth.Text = "D.O.B (DD/MM/YYYY)";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(17, 96);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(75, 24);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelIDNumber
            // 
            this.labelIDNumber.AutoSize = true;
            this.labelIDNumber.BackColor = System.Drawing.Color.Transparent;
            this.labelIDNumber.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIDNumber.Location = new System.Drawing.Point(17, 53);
            this.labelIDNumber.Name = "labelIDNumber";
            this.labelIDNumber.Size = new System.Drawing.Size(119, 24);
            this.labelIDNumber.TabIndex = 0;
            this.labelIDNumber.Text = "Id Number";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 662);
            this.Controls.Add(this.groupBoxStudents);
            this.Controls.Add(this.labelMenuPayments);
            this.Controls.Add(this.labelMenuGrades);
            this.Controls.Add(this.labelMenuResources);
            this.Controls.Add(this.labelMenuRooms);
            this.Controls.Add(this.labelMenuCourses);
            this.Controls.Add(this.labelMenuLectures);
            this.Controls.Add(this.labelMenuStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBoxStudents.ResumeLayout(false);
            this.groupBoxStudents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMenuStudents;
        private System.Windows.Forms.Label labelMenuLectures;
        private System.Windows.Forms.Label labelMenuCourses;
        private System.Windows.Forms.Label labelMenuResources;
        private System.Windows.Forms.Label labelMenuGrades;
        private System.Windows.Forms.Label labelMenuPayments;
        private System.Windows.Forms.Label labelMenuRooms;
        private System.Windows.Forms.GroupBox groupBoxStudents;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxDOB;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIdNumber;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelIDNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClearFields;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonSearch;
    }
}

