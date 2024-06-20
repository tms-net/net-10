using System;


namespace CcvSerializer
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CsvHeaderAttribute : Attribute
    {
        public string Header { get; }

        public CsvHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
