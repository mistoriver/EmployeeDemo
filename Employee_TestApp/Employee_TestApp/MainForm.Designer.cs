namespace Employee_TestApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmployeeDGV = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnForDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeDGV
            // 
            this.EmployeeDGV.AllowUserToAddRows = false;
            this.EmployeeDGV.AllowUserToDeleteRows = false;
            this.EmployeeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.EmployeeName,
            this.Gender,
            this.BirthDate,
            this.ColumnForDelete});
            this.EmployeeDGV.Location = new System.Drawing.Point(0, 26);
            this.EmployeeDGV.Name = "EmployeeDGV";
            this.EmployeeDGV.ReadOnly = true;
            this.EmployeeDGV.Size = new System.Drawing.Size(800, 395);
            this.EmployeeDGV.TabIndex = 1;
            this.EmployeeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Employee_CellOrItsContentContentClick);
            this.EmployeeDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Employee_CellOrItsContentContentClick);
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "EmployeeId";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            this.EmployeeId.Visible = false;
            // 
            // EmployeeName
            // 
            this.EmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmployeeName.FillWeight = 134.1752F;
            this.EmployeeName.HeaderText = "ФИО Сотрудника";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gender.FillWeight = 16.16569F;
            this.Gender.HeaderText = "Пол";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // BirthDate
            // 
            this.BirthDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BirthDate.FillWeight = 60F;
            this.BirthDate.HeaderText = "Дата рождения";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // ColumnForDelete
            // 
            this.ColumnForDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnForDelete.HeaderText = "";
            this.ColumnForDelete.Name = "ColumnForDelete";
            this.ColumnForDelete.ReadOnly = true;
            this.ColumnForDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnForDelete.Text = "X";
            this.ColumnForDelete.ToolTipText = "Удалить строку";
            this.ColumnForDelete.UseColumnTextForButtonValue = true;
            this.ColumnForDelete.Width = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(515, 0);
            this.SearchButton.MaximumSize = new System.Drawing.Size(285, 20);
            this.SearchButton.MinimumSize = new System.Drawing.Size(28, 20);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(285, 20);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AddEmployee
            // 
            this.AddEmployee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddEmployee.Location = new System.Drawing.Point(0, 427);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(800, 23);
            this.AddEmployee.TabIndex = 2;
            this.AddEmployee.Text = "Добавить сотрудника";
            this.AddEmployee.UseVisualStyleBackColor = true;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployee_Click);
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextbox.Location = new System.Drawing.Point(0, 0);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(517, 20);
            this.SearchTextbox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchTextbox);
            this.Controls.Add(this.AddEmployee);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.EmployeeDGV);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MainForm";
            this.Text = "Управление сотрудниками";
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeeDGV;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button AddEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnForDelete;
        private System.Windows.Forms.TextBox SearchTextbox;
    }
}

