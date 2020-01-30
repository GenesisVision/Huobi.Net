using System;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Huobi.Net.Objects
{
    public class HuobiAccountHistory
    {
        [JsonProperty("record-id")]
        public string Id { get; set; }
        
        [JsonProperty("account-id")]
        public long AccountId { get; set; }
        
        public string Currency { get; set; }
        
        [JsonProperty("transact-amt")]
        public decimal Amount { get; set; }
        
        [JsonProperty("transact-type")]
        public string Type { get; set; }
        
        [JsonProperty("transact-time"), JsonConverter(typeof(TimestampConverter))]
        public DateTime Time { get; set; }
    }
}