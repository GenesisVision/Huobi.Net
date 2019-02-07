﻿using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Huobi.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Huobi.Net.Objects
{
    public class HuobiOrder : IHuobiOrder
    {
        /// <summary>
        /// The id of the order
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The symbol of the order
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// The id of the account that placed the order
        /// </summary>
        [JsonProperty("account-id")]
        public long AccountId { get; set; }
        /// <summary>
        /// The amount of the order
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The price of the order
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
        
        /// <summary>
        /// The time the order was created
        /// </summary>
        [JsonProperty("created-at"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The time the order was canceled
        /// </summary>
        [JsonProperty("canceled-at"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CanceledAt { get; set; }
        /// <summary>
        /// The time the order was finished
        /// </summary>
        [JsonProperty("finished-at"), JsonConverter(typeof(TimestampConverter))]
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// The type of the order
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(OrderTypeConverter))]
        public HuobiOrderType Type { get; set; }

        /// <summary>
        /// The source of the order
        /// </summary>
        [JsonProperty("source"), JsonOptionalProperty]
        public string Source { get; set; }

        /// <summary>
        /// The state of the order
        /// </summary>
        [JsonProperty("state"), JsonConverter(typeof(OrderStateConverter))]
        public HuobiOrderState State { get; set; }

        /// <summary>
        /// The amount of the order that is filled
        /// </summary>
        [JsonProperty("field-amount")]
        public decimal FilledAmount { get; set; }

        [JsonProperty("field-cash-amount")]
        public decimal FilledCashAmount { get; set; }

        /// <summary>
        /// The amount of fees paid for the filled amount
        /// </summary>
        [JsonProperty("field-fees")]
        public decimal FilledFees { get; set; }
    }
}
