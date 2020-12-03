using System;
using Newtonsoft.Json;

namespace Huobi.Net.Objects.SocketObjects
{
    internal class HuobiRequest
    {
        [JsonIgnore]
        public string? Id { get; set; }
    }

    internal class HuobiKlineSocketRequest : HuobiSocketRequest
    {
        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        public HuobiKlineSocketRequest(string id, string topic, DateTime from, DateTime to) : base(id, topic)
        {
            var unixEpoch = new DateTime(1970, 1, 1);
            From = (long)(from - unixEpoch).TotalSeconds;
            To = (long)(to - unixEpoch).TotalSeconds;
        }
    }

    internal class HuobiSocketRequest: HuobiRequest
    {
        [JsonProperty("req")]
        public string Request { get; set; }

        [JsonProperty("id")]
        public new string Id { get; set; }

        public HuobiSocketRequest(string id, string topic)
        {
            Id = id;
            Request = topic;
        }
    }

    internal class HuobiAuthenticatedSubscribeRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("ch")]
        public string Channel { get; set; }

        public HuobiAuthenticatedSubscribeRequest(string channel, string action = "sub")
        {
            Action = action;
            Channel = channel;
        }
    }

    internal class HuobiSubscribeRequest: HuobiRequest
    {
        [JsonProperty("sub")]
        public string Topic { get; set; }
        [JsonProperty("id")]
        public new string Id { get; set; }

        public HuobiSubscribeRequest(string id, string topic)
        {
            Id = id;
            Topic = topic;
        }
    }
}
