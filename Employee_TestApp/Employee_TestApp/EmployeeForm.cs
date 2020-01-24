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
            SaveButton.Enabled = false;
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
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private bool NotEmptyOrNull()
        {
            return NameTextBox.Text != "" && GenderCombobox.SelectedItem != null &&
                   BirthDateTextbox.Text != "" &&
                   DocTypeCombobox.SelectedItem != null
                   && SeriesTextbox.Text != "" && NumberTextbox.Text != "" && DateToTextbox.Text != "" &&
                   DateFromTextbox.Text != "" && phoneTextBox.Text != "" &&
                   phoneTypeCBox.SelectedItem != null;
        }

        private bool ProperlyFilled()
        { 
            var lengths = BirthDateTextbox.Text.Length == 10 && DateToTextbox.Text.Length == 10 &&
                   DateFromTextbox.Text.Length == 10 &&
                   SeriesTextbox.Text.Length == 4 && NumberTextbox.Text.Length == 6;
            var dates = false;
            if (lengths)
                try
                {
                    dates = DateTime.Parse(BirthDateTextbox.Text) < DateTime.Parse(DateFromTextbox.Text) &&
                            DateTime.Parse(DateFromTextbox.Text) < DateTime.Parse(DateToTextbox.Text);
                }
                catch (Exception){}

            return lengths && dates;
        }

        /*private DateTime ParseTbDate(TextBox tb)
        {
            try
            {
                return DateTime.Parse(tb.Text);
            }
            catch
            {
                MessageBox.Show($"Некорректная дата: {tb.Text}")
            }
        }*/

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            if (NotEmptyOrNull())
            {
                var allGood = true;
                if (Emp == null)
                {
                    var empId = DbWorker.GetMaxId("Employees", "employee_id") + 1;
                    allGood = DbWorker.InsertData("Employees",
                        $"{empId}",
                        $"'{NameTextBox.Text}'", GenderCombobox.SelectedItem.ToString() == "М" ? "1" : "0",
                        $"'{BirthDateTextbox.Text}'");

                    var docId = DbWorker.GetMaxId("Employee_Documents", "doc_id")+1;
                    if (allGood)
                        allGood = DbWorker.InsertData("Employee_Documents", $"{empId}",
                        $"{docId}",
                        $"{SeriesTextbox.Text}{NumberTextbox.Text}",
                        $"{DocTypeCombobox.SelectedIndex}",
                        $"'{DateFromTextbox.Text}'",
                        $"'{DateToTextbox.Text}'");
                    var phoneId = DbWorker.GetMaxId("Employee_Phones", "phone_id")+1;
                    if (allGood)
                        allGood = DbWorker.InsertData("Employee_Phones", $"{phoneId}", 
                        $"{phoneTextBox.Text}", 
                        $"{empId}",
                        $"{phoneTypeCBox.SelectedIndex}");
                    else DbWorker.DeleteData("Employees", "employee_id", $"{empId}");//если плохо добавился док - надо удалить сотрудника
                    if (!allGood)
                    {
                        DbWorker.DeleteData("Employees", "employee_id", $"{docId}");//если плохо добавился телефон - надо удалить и сотрудника
                        DbWorker.DeleteData("Employee_Documents", "doc_id", $"{docId}");//и его документ
                    } 
                }
                else
                {
                    //для обновления это не нужно
                    allGood = DbWorker.UpdateData("Employees", "employee_id", Emp.Id, 
                        ("employee_name",$"'{NameTextBox.Text}'"),
                        ("is_male",GenderCombobox.SelectedItem.ToString() == "М" ? "1" : "0"), 
                        ("birth_date",$"'{BirthDateTextbox.Text}'"));
                    if (allGood)
                        allGood = DbWorker.UpdateData("Employee_Documents", "doc_id", Doc.DocId,
                            ("series_number",$"{SeriesTextbox.Text}{NumberTextbox.Text}"),
                            ("doc_type",$"{DocTypeCombobox.SelectedIndex}"),
                            ("from_date",$"'{DateFromTextbox.Text}'"),
                            ("by_date",$"'{DateToTextbox.Text}'"));
                    if (allGood)
                        allGood = DbWorker.UpdateData("Employee_Phones", "phone_id", Phone.Id,
                            ("phone_number",$"'{phoneTextBox.Text}'"),
                            ("phone_type",$"{phoneTypeCBox.SelectedIndex}"));
                }

                if (allGood) this.Close();
            }
            else MessageBox.Show("Заполнены не все поля!");
        }

        void PutEmployeeOnForm(Employee emp)
        {
            NameTextBox.Text = emp.Name;
            GenderCombobox.SelectedItem = emp.Gender;
            BirthDateTextbox.Text = emp.DateOfBirth.Split(' ')[0];
        }
        void PutDocOnForm(Document doc)
        {
            if (doc == null) return;
            DocTypeCombobox.SelectedIndex = Int32.Parse(doc.Type); //я знаю, какая тут может появиться проблема
            SeriesTextbox.Text = doc.Series;
            NumberTextbox.Text = doc.Number;
            DateToTextbox.Text = doc.ToDate;
            DateFromTextbox.Text = doc.FromDate;

        }
        void PutPhoneOnForm(EmpPhone phone)
        {
            phoneTextBox.Text = phone.PhoneNumber;
            phoneTypeCBox.SelectedIndex = Int32.Parse(phone.PhoneType);
        }
        

        private void BirthDateTextbox_TextChanged(object sender, EventArgs e)
        {
            Validator.DateValidator(BirthDateTextbox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private void SeriesTextbox_TextChanged(object sender, EventArgs e)
        {
            Validator.NumberValidator(SeriesTextbox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private void NumberTextbox_TextChanged(object sender, EventArgs e)
        {
            Validator.NumberValidator(NumberTextbox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private void DateFromTextbox_TextChanged(object sender, EventArgs e)
        {
            Validator.DateValidator(DateFromTextbox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private void DateToTextbox_TextChanged(object sender, EventArgs e)
        {
            Validator.DateValidator(DateToTextbox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            Validator.PhoneValidator(phoneTextBox);
            SaveButton.Enabled = NotEmptyOrNull() && ProperlyFilled();
        }
    }
}
