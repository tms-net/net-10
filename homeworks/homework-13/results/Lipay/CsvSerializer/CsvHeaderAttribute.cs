namespace CsvSerializer
{
    public class CsvHeaderAttribute : Attribute
    {
        public string HeaderName { get; set; }

        public CsvHeaderAttribute(string headerName)
        {
            HeaderName = headerName;
        }
    }
  
}
