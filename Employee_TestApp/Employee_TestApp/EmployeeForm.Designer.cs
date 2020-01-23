namespace Employee_TestApp
{
    partial class EmployeeForm
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
            this.FullNameLable = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.BirthDateTextbox = new System.Windows.Forms.TextBox();
            this.BirthDateLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SeriesTextbox = new System.Windows.Forms.TextBox();
            this.SeriesLabel = new System.Windows.Forms.Label();
            this.NumberTextbox = new System.Windows.Forms.TextBox();
            this.DocTypeLabel = new System.Windows.Forms.Label();
            this.DocTypeCombobox = new System.Windows.Forms.ComboBox();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.DateFromTextbox = new System.Windows.Forms.TextBox();
            this.DatefromLabel = new System.Windows.Forms.Label();
            this.DateToTextbox = new System.Windows.Forms.TextBox();
            this.DateToLabel = new System.Windows.Forms.Label();
            this.GenderCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FullNameLable
            // 
            this.FullNameLable.AutoSize = true;
            this.FullNameLable.Location = new System.Drawing.Point(7, 15);
            this.FullNameLable.Name = "FullNameLable";
            this.FullNameLable.Size = new System.Drawing.Size(34, 13);
            this.FullNameLable.TabIndex = 0;
            this.FullNameLable.Text = "ФИО";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(71, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(229, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(7, 41);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(27, 13);
            this.GenderLabel.TabIndex = 2;
            this.GenderLabel.Text = "Пол";
            // 
            // BirthDateTextbox
            // 
            this.BirthDateTextbox.Location = new System.Drawing.Point(201, 38);
            this.BirthDateTextbox.Name = "BirthDateTextbox";
            this.BirthDateTextbox.Size = new System.Drawing.Size(99, 20);
            this.BirthDateTextbox.TabIndex = 5;
            // 
            // BirthDateLabel
            // 
            this.BirthDateLabel.AutoSize = true;
            this.BirthDateLabel.Location = new System.Drawing.Point(109, 41);
            this.BirthDateLabel.Name = "BirthDateLabel";
            this.BirthDateLabel.Size = new System.Drawing.Size(86, 13);
            this.BirthDateLabel.TabIndex = 4;
            this.BirthDateLabel.Text = "Дата рождения";
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveButton.Location = new System.Drawing.Point(0, 191);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(313, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SeriesTextbox
            // 
            this.SeriesTextbox.Location = new System.Drawing.Point(71, 91);
            this.SeriesTextbox.Name = "SeriesTextbox";
            this.SeriesTextbox.Size = new System.Drawing.Size(77, 20);
            this.SeriesTextbox.TabIndex = 8;
            // 
            // SeriesLabel
            // 
            this.SeriesLabel.AutoSize = true;
            this.SeriesLabel.Location = new System.Drawing.Point(7, 94);
            this.SeriesLabel.Name = "SeriesLabel";
            this.SeriesLabel.Size = new System.Drawing.Size(38, 13);
            this.SeriesLabel.TabIndex = 7;
            this.SeriesLabel.Text = "Серия";
            // 
            // NumberTextbox
            // 
            this.NumberTextbox.Location = new System.Drawing.Point(201, 91);
            this.NumberTextbox.Name = "NumberTextbox";
            this.NumberTextbox.Size = new System.Drawing.Size(99, 20);
            this.NumberTextbox.TabIndex = 10;
            // 
            // DocTypeLabel
            // 
            this.DocTypeLabel.AutoSize = true;
            this.DocTypeLabel.Location = new System.Drawing.Point(7, 67);
            this.DocTypeLabel.Name = "DocTypeLabel";
            this.DocTypeLabel.Size = new System.Drawing.Size(58, 13);
            this.DocTypeLabel.TabIndex = 11;
            this.DocTypeLabel.Text = "Документ";
            // 
            // DocTypeCombobox
            // 
            this.DocTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocTypeCombobox.Location = new System.Drawing.Point(71, 64);
            this.DocTypeCombobox.Name = "DocTypeCombobox";
            this.DocTypeCombobox.Size = new System.Drawing.Size(229, 21);
            this.DocTypeCombobox.TabIndex = 12;
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(154, 94);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(41, 13);
            this.NumberLabel.TabIndex = 13;
            this.NumberLabel.Text = "Номер";
            // 
            // DateFromTextbox
            // 
            this.DateFromTextbox.Location = new System.Drawing.Point(83, 117);
            this.DateFromTextbox.Name = "DateFromTextbox";
            this.DateFromTextbox.Size = new System.Drawing.Size(217, 20);
            this.DateFromTextbox.TabIndex = 15;
            // 
            // DatefromLabel
            // 
            this.DatefromLabel.AutoSize = true;
            this.DatefromLabel.Location = new System.Drawing.Point(4, 120);
            this.DatefromLabel.Name = "DatefromLabel";
            this.DatefromLabel.Size = new System.Drawing.Size(73, 13);
            this.DatefromLabel.TabIndex = 14;
            this.DatefromLabel.Text = "Дата выдачи";
            // 
            // DateToTextbox
            // 
            this.DateToTextbox.Location = new System.Drawing.Point(105, 143);
            this.DateToTextbox.Name = "DateToTextbox";
            this.DateToTextbox.Size = new System.Drawing.Size(195, 20);
            this.DateToTextbox.TabIndex = 17;
            // 
            // DateToLabel
            // 
            this.DateToLabel.AutoSize = true;
            this.DateToLabel.Location = new System.Drawing.Point(4, 146);
            this.DateToLabel.Name = "DateToLabel";
            this.DateToLabel.Size = new System.Drawing.Size(95, 13);
            this.DateToLabel.TabIndex = 16;
            this.DateToLabel.Text = "Действителен до";
            // 
            // GenderCombobox
            // 
            this.GenderCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderCombobox.Items.AddRange(new object[] {
            "М",
            "Ж"});
            this.GenderCombobox.Location = new System.Drawing.Point(71, 37);
            this.GenderCombobox.Name = "GenderCombobox";
            this.GenderCombobox.Size = new System.Drawing.Size(35, 21);
            this.GenderCombobox.TabIndex = 18;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 214);
            this.Controls.Add(this.GenderCombobox);
            this.Controls.Add(this.DateToTextbox);
            this.Controls.Add(this.DateToLabel);
            this.Controls.Add(this.DateFromTextbox);
            this.Controls.Add(this.DatefromLabel);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.DocTypeCombobox);
            this.Controls.Add(this.DocTypeLabel);
            this.Controls.Add(this.NumberTextbox);
            this.Controls.Add(this.SeriesTextbox);
            this.Controls.Add(this.SeriesLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BirthDateTextbox);
            this.Controls.Add(this.BirthDateLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.FullNameLable);
            this.Name = "EmployeeForm";
            this.Text = "Работа с пользователями";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullNameLable;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.TextBox BirthDateTextbox;
        private System.Windows.Forms.Label BirthDateLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SeriesTextbox;
        private System.Windows.Forms.Label SeriesLabel;
        private System.Windows.Forms.TextBox NumberTextbox;
        private System.Windows.Forms.Label DocTypeLabel;
        private System.Windows.Forms.ComboBox DocTypeCombobox;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.TextBox DateFromTextbox;
        private System.Windows.Forms.Label DatefromLabel;
        private System.Windows.Forms.TextBox DateToTextbox;
        private System.Windows.Forms.Label DateToLabel;
        private System.Windows.Forms.ComboBox GenderCombobox;
    }
}