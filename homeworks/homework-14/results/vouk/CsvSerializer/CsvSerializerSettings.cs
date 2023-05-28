using System.Text;

namespace CsvSerializer
{
    public class CsvSerializerSettings
    {
        public CsvSerializerSettings()
        {

        }

        public string Delimiter { get; set; }
        public Encoding Encoding { get; set; }
        public bool HasHeader { get; set; }
        public char Quote { get; set; }
        public bool QuoteAllFields { get; set; }
        public bool QuoteNoFields { get; set; }
        public bool QuoteNoSpecialCharacters { get; set; }
        public bool QuoteStringOnly { get; set; }
        public bool SkipEmptyRows { get; set; }
        public bool SkipEmptyRowsStrict { get; set; }
        public bool SkipHeaderRecord { get; set; }
        public bool SkipRecordOnException { get; set; }
        public bool UseSingleLineHeaderInCsv { get; set; }
    }
}
