using System;

namespace Huobi.Net.Objects
{
    public interface IHuobiOrder
    {
        long Id { get; set; }
        long AccountId { get; set; }
        decimal Amount { get; set; }
        DateTime CreatedAt { get; set; }
        decimal FilledAmount { get; set; }
        decimal FilledCashAmount { get; set; }
        decimal FilledFees { get; set; }
        decimal Price { get; set; }
        string Source { get; set; }
        HuobiOrderState State { get; set; }
        string Symbol { get; set; }
        HuobiOrderType Type { get; set; }
    }
}