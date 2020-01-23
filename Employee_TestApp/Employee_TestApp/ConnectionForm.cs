using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
            conStringTextBox.Text =
                @"Data Source=.\SQLExpress;Initial Catalog=Employee_TestDB;Trusted_Connection=True;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DbWorker.Check(conStringTextBox.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
