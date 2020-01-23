using System;

namespace Employee_TestApp
{
    public class Document
    {
        public string DocId { get; }
        public string EmpId { get; }
        public string Series { get; }
        public string Number { get; }
        public string Type { get; }
        public string FromDate { get; }
        public string ToDate { get; }

        public Document(string docId, string empId, string series, string number, string type, string fromDate, string toDate )
        {
            DocId = docId;
            EmpId = empId;
            Series = series;
            Number = number;
            Type = type;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
