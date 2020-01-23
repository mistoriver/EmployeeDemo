using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public partial class EmployeeForm : Form
    {
        Employee Emp { get; set; }
        Document Doc { get; set; }
        EmpPhone Phone { get; set; }
        public EmployeeForm()
        {
            InitializeComponent();
            Emp = null;
            DbWorker.FillDocTypes().ForEach(type => DocTypeCombobox.Items.Add(type));
            DbWorker.FillPhoneTypes().ForEach(type => phoneTypeCBox.Items.Add(type));
            this.Text = "Создание пользователя";
        }

        public EmployeeForm(Employee emp) : this()
        {
            this.Text = "Просмотр и редактирование пользователя";
            PutEmployeeOnForm(emp);
            Doc = DbWorker.GetDocument(empId:emp.Id);
            PutDocOnForm(Doc);
            Emp = emp;
            Phone = DbWorker.GetPhone(empId:emp.Id);
            PutPhoneOnForm(Phone);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && GenderCombobox.SelectedItem != null && BirthDateTextbox.Text != "" &&
                DocTypeCombobox.SelectedItem != null
                && SeriesTextbox.Text != "" && NumberTextbox.Text != "" && DateToTextbox.Text != "" &&
                DateFromTextbox.Text != "" && phoneTextBox.Text != "" &&
                phoneTypeCBox.SelectedItem != null)
            {
                var needToClose = true;
                if (Emp == null)
                {
                    var empId = DbWorker.GetMaxId("Employees", "employee_id") + 1;
                    needToClose = DbWorker.InsertData("Employees",
                        $"{empId}",
                        $"'{NameTextBox.Text}'", GenderCombobox.SelectedItem == "М" ? "1" : "0",
                        $"'{BirthDateTextbox.Text}'");
                    if (needToClose)
                        needToClose = DbWorker.InsertData("Employee_Documents", $"{empId}",
                        $"{DbWorker.GetMaxId("Employee_Documents", "doc_id")}",
                        $"{SeriesTextbox.Text.Concat(NumberTextbox.Text)}",
                        $"{DocTypeCombobox.SelectedIndex}",
                        $"'{DateFromTextbox.Text}'",
                        $"'{DateToTextbox.Text}'");
                    if (needToClose)
                        needToClose = DbWorker.InsertData("Employee_Phones", $"{phoneTextBox.Text}", 
                        $"{empId}",
                        $"{phoneTypeCBox.SelectedIndex}");
                }
                else
                {
                    needToClose = DbWorker.UpdateData("Employees", "employee_id", Emp.Id, $"{Emp.Id}",
                        $"'{NameTextBox.Text}'",
                        GenderCombobox.SelectedItem == "М" ? "1" : "0", $"'{BirthDateTextbox.Text}'");
                    if (needToClose)
                        needToClose = DbWorker.UpdateData("Employee_Documents", "doc_id", Doc.DocId,$"{Emp.Id}",
                            $"{Doc.DocId}",
                            $"{SeriesTextbox.Text.Concat(NumberTextbox.Text)}",
                            $"{DocTypeCombobox.SelectedIndex}",
                            $"'{DateFromTextbox.Text}'",
                            $"'{DateToTextbox.Text}'");
                    if (needToClose)
                        needToClose = DbWorker.UpdateData("Employee_Phones", "phone_number", phoneTextBox.Text,$"{phoneTextBox.Text}", 
                            $"{Emp.Id}",
                            $"{phoneTypeCBox.SelectedIndex}");
                }

                if (needToClose) this.Close();
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
        public void PutPhoneOnForm(EmpPhone phone)
        {
            phoneTextBox.Text = phone.PhoneNumber;
            phoneTypeCBox.SelectedIndex = Int32.Parse(phone.PhoneType)-1;
        }

        #region Validators

        public void DateValidator(TextBox tb)
        {
            if  (tb.Text.Replace(".", "").Length > 8)
                tb.Text = tb.Text.Substring(0,10);
            if (tb.TextLength > 2 && tb.Text[2] != '.')
                tb.Text = tb.Text.Insert(2, ".");
            if (tb.TextLength > 5 && tb.Text[5] != '.')
                tb.Text = tb.Text.Insert(5, ".");
            var rx = new Regex(@"(^\d$|^\d{2}$|^\d{2}[.]$|^\d{2}[.]\d$|^\d{2}[.]\d{2}$|^\d{2}[.]\d{2}[.]$|^\d{2}[.]\d{2}[.]\d$|^\d{2}[.]\d{2}[.]\d{2}$|^\d{2}[.]\d{2}[.]\d{3}$|^\d{2}[.]\d{2}[.]\d{4}$)");
            if (!rx.IsMatch(tb.Text))
            {
                string s = "";
                foreach (Match match in new Regex(@"\d*").Matches(tb.Text))
                {
                    s += match.Value;
                }
                tb.Text = s;
            }
            tb.SelectionStart = tb.TextLength;
        }

        public void NumberValidator(TextBox tb)
        {
            if (!new Regex(@"^\d*$").IsMatch(tb.Text))
            {
                string s = "";
                foreach (Match match in new Regex(@"(\d*|[.])").Matches(tb.Text))
                {
                    s += match.Value;
                }
                tb.Text = s;
            }
            tb.SelectionStart = tb.TextLength;
        }

        public void PhoneValidator(TextBox tb)
        {
            NumberValidator(tb);
            if (tb.Text.Length > 10)
            {
                if (tb.Text[0] == '7') tb.Text = tb.Text.Substring(1);
                tb.Text = tb.Text.Substring(0, 10);
            }
        }

        #endregion
        

        private void BirthDateTextbox_TextChanged(object sender, EventArgs e)
        {
            DateValidator(BirthDateTextbox);
        }

        private void SeriesTextbox_TextChanged(object sender, EventArgs e)
        {
            NumberValidator(SeriesTextbox);
        }

        private void NumberTextbox_TextChanged(object sender, EventArgs e)
        {
            NumberValidator(NumberTextbox);
        }

        private void DateFromTextbox_TextChanged(object sender, EventArgs e)
        {
            DateValidator(DateFromTextbox);
        }

        private void DateToTextbox_TextChanged(object sender, EventArgs e)
        {
            DateValidator(DateToTextbox);
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneValidator(phoneTextBox);
        }
    }
}
