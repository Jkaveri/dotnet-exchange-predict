namespace ExchangePredict.BuildBlocks.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;

    public class ExchangeRate
    {
        public ExchangeRate()
        {
        }

        public ExchangeRate(
            DateTime timeStamp,
            Dictionary<string, decimal> rates,
            string @base = "USD")
        {
            Base = @base;
            TimeStamp = timeStamp;
            Rates = rates;
        }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }

        public string Base { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }
    }
}
