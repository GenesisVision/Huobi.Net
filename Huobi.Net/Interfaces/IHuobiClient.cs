﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Huobi.Net.Objects;

namespace Huobi.Net.Interfaces
{
    /// <summary>
    /// Interface for the Huobi client
    /// </summary>
    public interface IHuobiClient: IRestClient
    {
        /// <summary>
        /// Whether public requests should be signed if ApiCredentials are provided. Needed for accurate rate limiting.
        /// </summary>
        bool SignPublicRequests { get; }

        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
        void SetApiCredentials(string apiKey, string apiSecret);

        /// <summary>
        /// Gets the latest ticker for all symbols
        /// </summary>
        /// <returns></returns>
        WebCallResult<HuobiSymbolTicks> GetTickers(CancellationToken ct = default);

        /// <summary>
        /// Gets the latest ticker for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiSymbolTicks>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the ticker, including the best bid / best ask for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the ticker for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiSymbolTickMerged> GetMergedTickers(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the ticker, including the best bid / best ask for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the ticker for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiSymbolTickMerged>> GetMergedTickersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get candlestick data for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="period">The period of a single candlestick</param>
        /// <param name="size">The amount of candlesticks</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiKline>> GetKlines(string symbol, HuobiPeriod period, int size, CancellationToken ct = default);

        /// <summary>
        /// Get candlestick data for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="period">The period of a single candlestick</param>
        /// <param name="size">The amount of candlesticks</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiKline>>> GetKlinesAsync(string symbol, HuobiPeriod period, int size, CancellationToken ct = default);

        /// <summary>
        /// Gets the order book for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to request for</param>
        /// <param name="mergeStep">The way the results will be merged together</param>
        /// <param name="limit">The depth of the book</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiOrderBook> GetOrderBook(string symbol, int mergeStep, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the order book for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to request for</param>
        /// <param name="mergeStep">The way the results will be merged together</param>
        /// <param name="limit">The depth of the book</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiOrderBook>> GetOrderBookAsync(string symbol, int mergeStep, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the last trade for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to request for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiSymbolTrade> GetLastTrade(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the last trade for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to request for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiSymbolTrade>> GetLastTradeAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get the last x trades for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get trades for</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiSymbolTrade>> GetTradeHistory(string symbol, int limit, CancellationToken ct = default);

        /// <summary>
        /// Get the last x trades for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get trades for</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiSymbolTrade>>> GetTradeHistoryAsync(string symbol, int limit, CancellationToken ct = default);

        /// <summary>
        /// Gets 24h stats for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiSymbolDetails> GetSymbolDetails24H(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets 24h stats for a symbol
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiSymbolDetails>> GetSymbolDetails24HAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of supported symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiSymbol>> GetSymbols(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of supported symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiSymbol>>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<string>> GetCurrencies(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<string>>> GetCurrenciesAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the server time
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<DateTime> GetServerTime(CancellationToken ct = default);

        /// <summary>
        /// Gets the server time
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of accounts associated with the apikey/secret
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiAccountBalances>> GetAccounts(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of accounts associated with the apikey/secret
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiAccountBalances>>> GetAccountsAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a specific account
        /// </summary>
        /// <param name="accountId">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiBalance>> GetBalances(long accountId, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a specific account
        /// </summary>
        /// <param name="accountId">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiBalance>>> GetBalancesAsync(long accountId, CancellationToken ct = default);

        WebCallResult<IEnumerable<HuobiAccountHistory>> GetAccountHistory(long accountId, string? currency = null, string? transactTypes = null, DateTime? startTime = null, DateTime? endTime = null, string? sort = null, int? size = null, CancellationToken ct = default);

        Task<WebCallResult<IEnumerable<HuobiAccountHistory>>> GetAccountHistoryAsync(long accountId, string? currency = null, string? transactTypes = null, DateTime? startTime = null, DateTime? endTime = null, string? sort = null, int? size = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a specific sub account
        /// </summary>
        /// <param name="subAccountId">The id of the sub account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiBalance>> GetSubAccountBalances(long subAccountId, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a specific sub account
        /// </summary>
        /// <param name="subAccountId">The id of the sub account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiBalance>>> GetSubAccountBalancesAsync(long subAccountId, CancellationToken ct = default);

        /// <summary>
        /// Transfer asset between parent and sub account
        /// </summary>
        /// <param name="subAccountId">The target sub account id to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <param name="transferType">The type of transfer</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Unique transfer id</returns>
        WebCallResult<long> TransferWithSubAccount(long subAccountId, string currency, decimal amount, HuobiTransferType transferType, CancellationToken ct = default);

        /// <summary>
        /// Transfer asset between parent and sub account
        /// </summary>
        /// <param name="subAccountId">The target sub account id to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <param name="transferType">The type of transfer</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Unique transfer id</returns>
        Task<WebCallResult<long>> TransferWithSubAccountAsync(long subAccountId, string currency, decimal amount, HuobiTransferType transferType, CancellationToken ct = default);

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="accountId">The account to place the order for</param>
        /// <param name="symbol">The symbol to place the order for</param>
        /// <param name="orderType">The type of the order</param>
        /// <param name="amount">The amount of the order</param>
        /// <param name="price">The price of the order. Should be omitted for market orders</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<long> PlaceOrder(long accountId, string symbol, HuobiOrderType orderType, decimal amount, decimal? price = null, CancellationToken ct = default);

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="accountId">The account to place the order for</param>
        /// <param name="symbol">The symbol to place the order for</param>
        /// <param name="orderType">The type of the order</param>
        /// <param name="amount">The amount of the order</param>
        /// <param name="price">The price of the order. Should be omitted for market orders</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<long>> PlaceOrderAsync(long accountId, string symbol, HuobiOrderType orderType, decimal amount, decimal? price = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of open orders
        /// </summary>
        /// <param name="accountId">The account id for which to get the orders for</param>
        /// <param name="symbol">The symbol for which to get the orders for</param>
        /// <param name="side">Only get buy or sell orders</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiOpenOrder>> GetOpenOrders(long? accountId = null, string? symbol = null, HuobiOrderSide? side = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of open orders
        /// </summary>
        /// <param name="accountId">The account id for which to get the orders for</param>
        /// <param name="symbol">The symbol for which to get the orders for</param>
        /// <param name="side">Only get buy or sell orders</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiOpenOrder>>> GetOpenOrdersAsync(long? accountId = null, string? symbol = null, HuobiOrderSide? side = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Cancels an open order
        /// </summary>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<long> CancelOrder(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Cancels an open order
        /// </summary>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<long>> CancelOrderAsync(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple open orders
        /// </summary>
        /// <param name="orderIds">The ids of the orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiBatchCancelResult> CancelOrders(IEnumerable<long> orderIds, CancellationToken ct = default);

        /// <summary>
        /// Cancel multiple open orders
        /// </summary>
        /// <param name="orderIds">The ids of the orders to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchCancelResult>> CancelOrdersAsync(IEnumerable<long> orderIds, CancellationToken ct = default);

        /// <summary>
        /// Get details of an order
        /// </summary>
        /// <param name="orderId">The id of the order to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<HuobiOrder> GetOrderInfo(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Get details of an order
        /// </summary>
        /// <param name="orderId">The id of the order to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiOrder>> GetOrderInfoAsync(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of trades made for a specific order
        /// </summary>
        /// <param name="orderId">The id of the order to get trades for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiOrderTrade>> GetOrderTrades(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of trades made for a specific order
        /// </summary>
        /// <param name="orderId">The id of the order to get trades for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiOrderTrade>>> GetOrderTradesAsync(long orderId, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of orders
        /// </summary>
        /// <param name="symbol">The symbol to get orders for</param>
        /// <param name="states">The states of orders to return</param>
        /// <param name="types">The types of orders to return</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="fromId">Only get orders with before or after this. Used together with the direction parameter</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiOrder>> GetOrders(IEnumerable<HuobiOrderState> states, string? symbol = null, IEnumerable<HuobiOrderType>? types = null, DateTime? startTime = null, DateTime? endTime = null, long? fromId = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of orders
        /// </summary>
        /// <param name="symbol">The symbol to get orders for</param>
        /// <param name="states">The states of orders to return</param>
        /// <param name="types">The types of orders to return</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="fromId">Only get orders with before or after this. Used together with the direction parameter</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiOrder>>> GetOrdersAsync(IEnumerable<HuobiOrderState> states, string? symbol = null, IEnumerable<HuobiOrderType>? types = null, DateTime? startTime = null, DateTime? endTime = null, long? fromId = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of trades for a specific symbol
        /// </summary>
        /// <param name="states">Only return trades with specific states</param>
        /// <param name="symbol">The symbol to retrieve trades for</param>
        /// <param name="types">The type of orders to return</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="fromId">Only get orders with before or after this. Used together with the direction parameter</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiOrderTrade>> GetSymbolTrades(IEnumerable<HuobiOrderState>? states = null, string? symbol = null, IEnumerable<HuobiOrderType>? types = null, DateTime? startTime = null, DateTime? endTime = null, long? fromId = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of trades for a specific symbol
        /// </summary>
        /// <param name="states">Only return trades with specific states</param>
        /// <param name="symbol">The symbol to retrieve trades for</param>
        /// <param name="types">The type of orders to return</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="fromId">Only get orders with before or after this. Used together with the direction parameter</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiOrderTrade>>> GetSymbolTradesAsync(IEnumerable<HuobiOrderState>? states = null, string? symbol = null, IEnumerable<HuobiOrderType>? types = null, DateTime? startTime = null, DateTime? endTime = null, long? fromId = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of history orders
        /// </summary>
        /// <param name="symbol">The symbol to get orders for</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<HuobiOrder>> GetHistoryOrders(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of history orders
        /// </summary>
        /// <param name="symbol">The symbol to get orders for</param>
        /// <param name="startTime">Only get orders after this date</param>
        /// <param name="endTime">Only get orders before this date</param>
        /// <param name="direction">Direction of the results to return when using the fromId parameter</param>
        /// <param name="limit">The max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiOrder>>> GetHistoryOrdersAsync(string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, HuobiFilterDirection? direction = null, int? limit = null, CancellationToken ct = default);

    }
}