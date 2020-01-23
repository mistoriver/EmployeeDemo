using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Employee_TestApp
{
    public delegate void ReadContentHandler(params object[] parameters);
    public static class DBWorker
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

        private static string conString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RSHB_TestDB;Integrated Security=True"; //Это стоило бы вынести в файл
        private static SqlConnection connection = new SqlConnection(conString);
        public static void GetActualData(ReadContentHandler handler)
        {
            AddReadHandler(handler);
            connection.Open();
            SqlDataReader reader = SelectData("Employees");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dafuq = reader["is_male"].ToString();
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
        
        public static List<string> FillTypes()
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

        public static void InsertData(string tableName, params object[] values)
        {
            var comText = $"insert into {tableName} values(";
            foreach (var value in values)
            {
                comText += $"{value.ToString()}, ";
            }
            var lastPrep = comText.LastIndexOf(", ");
            if (lastPrep >= 0)
                comText = comText.Remove(lastPrep, 2);
            comText += ")";
            connection.Open();
            SqlCommand com = new SqlCommand(comText, connection);
            try { com.ExecuteScalar(); }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message); 
            }
            finally
            {
                connection.Close();
            }
        }

        public static void UpdateData(string tableName, string idColumn, string idValue, params object[] values)
        {
            DeleteData(tableName,idColumn,idValue);
            InsertData(tableName,values);
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
            foreach (var param in parameters)
            {
                comText += $"{param.column} like '%{param.substring}%' or ";
            }

            var lastOr = comText.LastIndexOf("or ");
            if (lastOr >= 0)
                comText = comText.Remove(lastOr, 3);
            
            SqlCommand com = new SqlCommand(comText, connection);
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
