using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_TestApp
{
    static class Validator
    {
        private static void ActionWithCorrectPosition(this TextBox tb, Action action)
        {
            var currentPos = tb.SelectionStart;
            var currentLength = tb.Text.Length;
            action.Invoke();
            var diff = tb.Text.Length - currentLength;
            var newPos = currentPos + diff+1;
            tb.SelectionStart = newPos > 0? newPos : 0;
            var dot1 = (tb.SelectionStart > 0 && tb.Text[tb.SelectionStart - 1] == '.') ? 1 : 0;
            tb.SelectionStart += dot1;
        }
        public static void DateValidator(TextBox tb)
        {
            //var symbolEntered = (tb.TextLength .SelectionStart > 0)? 
            if (tb.Text.Replace(".", "").Length > 8)
                tb.ActionWithCorrectPosition(() => { tb.Text = tb.Text.Substring(0, 10);});
            if (tb.TextLength > 2 && tb.Text[2] != '.')
                tb.ActionWithCorrectPosition( () => { tb.Text = tb.Text.Insert(2, ".");});
            if (tb.TextLength > 5 && tb.Text[5] != '.')
                tb.ActionWithCorrectPosition(() => { tb.Text = tb.Text.Insert(5, "."); });
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
            //tb.SelectionStart = tb.TextLength;
        }

        public static void NumberValidator(TextBox tb)
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

        public static void PhoneValidator(TextBox tb)
        {
            NumberValidator(tb);
            if (tb.Text.Length > 10)
            {
                if (tb.Text[0] == '7') tb.Text = tb.Text.Substring(1);
                tb.Text = tb.Text.Substring(0, 10);
            }
        }
    }
}
