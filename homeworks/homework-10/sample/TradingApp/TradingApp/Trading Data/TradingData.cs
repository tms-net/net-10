using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TradingApp.Data
{
    public class TradingData
    {
        private string _password = "password";

        // публичный конструктор по умолчанию
        public TradingData()
        {
        }

        // правильные модификаторы доступа
        public string Version { get; set; }

        [JsonPropertyName("metadata")]
        public TradingMedatata MetaData { get; set; }

        [JsonPropertyName("data")]
        [XmlElement(ElementName = "data")]
        public PriceData Data { get; set; }

        // циклические ссылки
        public TradingData OldData { get; set; }

        public TradingData NewData { get; set; }
    }

    public class TradingMedatata
    {
    }

    public class PriceData
    {
    }
}
