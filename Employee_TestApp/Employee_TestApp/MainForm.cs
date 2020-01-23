using System;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public partial class MainForm : Form
    {
        EmployeeForm ef { get; set; }
        public MainForm()
        {
            InitializeComponent();
            DBWorker.GetActualData(AddDGV);
        }


        public void AddDGV(params object [] parameters)
        {
            EmployeeDGV.Rows.Add(parameters);
        }

        public void ClearAndFillDGV(params object [] parameters)
        {
            
            EmployeeDGV.Rows.Add(parameters);
        }

        private void Employee_CellOrItsContentContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == EmployeeDGV.Columns.Count-1)
            {
                DBWorker.DeleteData("Employees", "employee_id", EmployeeDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                EmployeeDGV.Rows.RemoveAt(e.RowIndex);
                return;
            }
            var stringRow = new string[] //я этим не горжусь :(
            {
                EmployeeDGV.Rows[e.RowIndex].Cells[0].Value.ToString(),
                EmployeeDGV.Rows[e.RowIndex].Cells[1].Value.ToString(),
                EmployeeDGV.Rows[e.RowIndex].Cells[2].Value.ToString(),
                EmployeeDGV.Rows[e.RowIndex].Cells[3].Value.ToString()
            };
            ef = new EmployeeForm(new Employee(stringRow));
            ef.Owner = this;
            ef.ShowDialog();
            
            EmployeeDGV.Rows.Clear();
            EmployeeDGV.Update();
            DBWorker.GetActualData(AddDGV);
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            ef = new EmployeeForm();
            ef.Owner = this;
            ef.ShowDialog();
            EmployeeDGV.Rows.Clear();
            EmployeeDGV.Update();
            DBWorker.GetActualData(AddDGV);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            EmployeeDGV.Rows.Clear();
            EmployeeDGV.Update();
            DBWorker.GetFilteredData(AddDGV, SearchTextbox.Text);
        }
    }
}
