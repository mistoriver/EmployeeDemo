using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public delegate void ReadContentHandler(params object[] parameters);
    public static class DbWorker
    {
        #region IO Handlers
        private static ReadContentHandler _readContentHandler;

        public static void AddReadHandler(ReadContentHandler handler)
        {
            _readContentHandler += handler;
        }

        public static void RemoveReadHandler(ReadContentHandler handler)
        {
            _readContentHandler -= handler;
        }
        public static void RemoveLastReadHandler()
        {
            _readContentHandler -= (ReadContentHandler)_readContentHandler.GetInvocationList().LastOrDefault();
        }
        #endregion

        public static string conString { get; private set; }// @"Data Source=.\SQLExpress;Initial Catalog=Employee_TestDB;Trusted_Connection=True;";
        private static SqlConnection connection ;//= new SqlConnection(conString);

        

        public static bool Check(string cs)
        {
            try
            {
                conString = cs;
                connection = new SqlConnection(conString);
                connection.Open();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static void GetActualData(ReadContentHandler handler)
        {
            AddReadHandler(handler);
            connection.Open();
            SqlDataReader reader = SelectData("Employees");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _readContentHandler?.Invoke(reader["employee_id"], reader["employee_name"], (reader["is_male"].ToString().Contains("True")) ? "М" : "Ж", reader["birth_date"]);
                }
            }
            connection.Close();
            RemoveReadHandler(handler);
        }

        public static void GetFilteredData(ReadContentHandler handler, string filter)
        {
            AddReadHandler(handler);
            connection.Open();
            SqlDataReader reader = SelectSubstringData("Employees", ("employee_name", filter), ("birth_date", filter));
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _readContentHandler?.Invoke(reader["employee_id"], reader["employee_name"], (reader["is_male"].ToString().Contains("True")) ? "М" : "Ж", reader["birth_date"]);
                }
            }
            connection.Close();
            RemoveReadHandler(handler);
        }
        
        public static List<string> FillDocTypes()
        {
            List<string> res = new List<string>();
            connection.Open();
            SqlDataReader reader = SelectData("Doc_Types");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res.Add(reader.GetString(1));
                }
            }
            connection.Close();
            return res;
        }

        public static List<string> FillPhoneTypes()
        {
            List<string> res = new List<string>();
            connection.Open();
            SqlDataReader reader = SelectData("Phone_Types");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    res.Add(reader.GetString(1));
                }
            }
            connection.Close();
            return res;
        }

        public static Document GetDocument(string docId = null, string empId = null)
        {
            Document doc = null;
            if (docId != null || empId != null)
            {
                connection.Open();
                
                var par = docId == null ? ("employee_id", empId) : ("doc_id", docId);
                SqlDataReader reader = SelectData("Employee_Documents", par);
                if (reader.HasRows)
                {
                    reader.Read();
                    doc = new Document(reader[1].ToString(), reader[0].ToString(), reader[2].ToString().Substring(0,4)
                        , reader[2].ToString().Substring(4), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                }
                connection.Close();
            }
            return doc;
        }
        public static EmpPhone GetPhone(string phoneNumber = null, string empId = null)
        {
            EmpPhone phone = null;
            if (phoneNumber != null || empId != null)
            {
                connection.Open();
                
                var par = phoneNumber == null ? ("employee_id", empId) : ("phone_number", phoneNumber);
                SqlDataReader reader = SelectData("Employee_Phones", par);
                if (reader.HasRows)
                {
                    reader.Read();
                    phone = new EmpPhone(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                }
                connection.Close();
            }
            return phone;
        }

        public static bool InsertData(string tableName, params object[] values)
        {
            var result = false;
            var comText = $"insert into {tableName} values(";

            for (int i = 0; i < values.Length; i++)
            {
                comText += values[i]; //$"@value{i}, ";
            }
            var lastPrep = comText.LastIndexOf(", ");
            if (lastPrep >= 0)
                comText = comText.Remove(lastPrep, 2);
            comText += ")";
            
            SqlCommand com = new SqlCommand(comText, connection);
           /* for (int i = 0; i < values.Length; i++)
            {
                var param = new SqlParameter($"@value{i}",values[i]);
                com.Parameters.Add(param);
            }*/
            connection.Open();
            try 
            { 
                com.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message); 
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public static bool UpdateData(string tableName, string idColumn, string idValue, params object[] values)
        {
            DeleteData(tableName,idColumn,idValue);
            return InsertData(tableName,values);
        }

        public static void DeleteData(string tableName, string column, string exactValue)
        {
            var comText = $"delete from {tableName} where {column} = {exactValue}";
            connection.Open();
            SqlCommand com = new SqlCommand(comText, connection);
            try { com.ExecuteScalar(); }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
        }

        private static SqlDataReader SelectData(string tableName, params (string column, string exactValue)[] parameters)
        {
            SqlDataReader reader = null;
            var comText = $"select * from {tableName}";
            if (parameters?.Length > 0)
                comText += " where ";
            foreach (var param in parameters)
            {
                comText += $"{param.column} = {param.exactValue} and ";
            }

            var lastAnd = comText.LastIndexOf("and ");
            if (lastAnd >= 0)
                comText = comText.Remove(lastAnd, 4);
            
            SqlCommand com = new SqlCommand(comText, connection);
            reader = com.ExecuteReader();
            return reader;
        }
        private static SqlDataReader SelectSubstringData(string tableName, params (string column, string substring)[] parameters)
        {
            SqlDataReader reader = null;
            var comText = $"select * from {tableName}";
            if (parameters?.Length > 0)
                comText += " where ";
            var i = 0;
            foreach (var param in parameters)
            {
                comText += $"{param.column} like '%{param.substring}%' or ";
                i++;
            }

            var lastOr = comText.LastIndexOf("or ");
            if (lastOr >= 0)
                comText = comText.Remove(lastOr, 3);
            
            SqlCommand com = new SqlCommand(comText, connection);
            //com.Parameters.Add(new SqlParameter("@TableName", tableName));
            
            i = 0;
            foreach (var param in parameters)
            {
                com.Parameters.AddWithValue($"@Column{i}", param.column);
                com.Parameters.AddWithValue($"@Substring{i}", param.substring);
                i++;
            }
            reader = com.ExecuteReader();
            return reader;
        }

        public static int GetMaxId(string tableName, string idName)
        {
            int res = -1;
            var comText = $"select max({idName}) from {tableName}";
            connection.Open();
            SqlCommand com = new SqlCommand(comText, connection);
            try
            {
                Int32.TryParse(com.ExecuteScalar().ToString(), out res);
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return res;
        }
    }
}
