using System;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public partial class EmployeeForm : Form
    {
        Employee Emp { get; set; }
        public EmployeeForm()
        {
            InitializeComponent();
            Emp = null;
            DBWorker.FillTypes().ForEach(type => DocTypeCombobox.Items.Add(type));
            this.Text = "Создание пользователя";
        }

        public EmployeeForm(Employee emp) : this()
        {
            this.Text = "Просмотр и редактирование пользователя";
            PutEmployeeOnForm(emp);
            PutDocOnForm(DBWorker.GetDocument(empId:emp.Id));
            Emp = emp;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && GenderCombobox.SelectedItem != null && BirthDateTextbox.Text != "" &&
                DocTypeCombobox.SelectedItem != null
                && SeriesTextbox.Text != "" && NumberTextbox.Text != "" && DateToTextbox.Text != "" &&
                DateFromTextbox.Text != "")
            {
                if (Emp == null)
                    DBWorker.InsertData("Employees", $"{DBWorker.GetMaxId("Employees", "employee_id") + 1}",
                        $"'{NameTextBox.Text}'", GenderCombobox.SelectedItem == "М" ? "1" : "0",
                        $"'{BirthDateTextbox.Text}'");
                else
                    DBWorker.UpdateData("Employees", "employee_id", Emp.Id, $"{Emp.Id}", $"'{NameTextBox.Text}'",
                        GenderCombobox.SelectedItem == "М" ? "1" : "0", $"'{BirthDateTextbox.Text}'");
                this.Close();
            }
            else MessageBox.Show("Заполнены не все поля!");
        }

        public void PutEmployeeOnForm(Employee emp)
        {
            NameTextBox.Text = emp.Name;
            GenderCombobox.SelectedItem = emp.Gender;
            BirthDateTextbox.Text = emp.DateOfBirth.Split(' ')[0];
        }
        public void PutDocOnForm(Document doc)
        {
            if (doc == null) return;
            DocTypeCombobox.SelectedIndex = Int32.Parse(doc.Type)-1; //я знаю, какая тут может появиться проблема
            SeriesTextbox.Text = doc.Series;
            NumberTextbox.Text = doc.Number;
            DateToTextbox.Text = doc.ToDate;
            DateFromTextbox.Text = doc.FromDate;

        }
    }
}
