using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public class EmpPhone
    {
        public string PhoneNumber { get; }
        public string EmpId { get; }
        public string PhoneType { get; }
        public EmpPhone(string phoneNumber, string empId, string phoneType )
        {
            PhoneNumber = phoneNumber;
            EmpId = empId;
            PhoneType = phoneType;
        }
    }
}
