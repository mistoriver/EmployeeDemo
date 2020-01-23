namespace Employee_TestApp
{
    partial class ConnectionForm
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
            this.checkAndSaveConnection = new System.Windows.Forms.Button();
            this.conStringTextBox = new System.Windows.Forms.TextBox();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkAndSaveConnection
            // 
            this.checkAndSaveConnection.Location = new System.Drawing.Point(12, 65);
            this.checkAndSaveConnection.Name = "checkAndSaveConnection";
            this.checkAndSaveConnection.Size = new System.Drawing.Size(458, 23);
            this.checkAndSaveConnection.TabIndex = 0;
            this.checkAndSaveConnection.Text = "Сохранить";
            this.checkAndSaveConnection.UseVisualStyleBackColor = true;
            this.checkAndSaveConnection.Click += new System.EventHandler(this.button1_Click);
            // 
            // conStringTextBox
            // 
            this.conStringTextBox.Location = new System.Drawing.Point(12, 38);
            this.conStringTextBox.Name = "conStringTextBox";
            this.conStringTextBox.Size = new System.Drawing.Size(458, 20);
            this.conStringTextBox.TabIndex = 1;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(12, 13);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(286, 13);
            this.connectionLabel.TabIndex = 2;
            this.connectionLabel.Text = "Введите строку подключения для начала работы с БД:";
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 100);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.conStringTextBox);
            this.Controls.Add(this.checkAndSaveConnection);
            this.Name = "ConnectionForm";
            this.Text = "Подключение к БД";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkAndSaveConnection;
        private System.Windows.Forms.TextBox conStringTextBox;
        private System.Windows.Forms.Label connectionLabel;
    }
}