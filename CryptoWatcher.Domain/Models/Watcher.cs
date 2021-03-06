﻿using System;
using CesarBmx.Shared.Domain.Models;
using CryptoWatcher.Domain.Builders;
using CryptoWatcher.Domain.Types;


namespace CryptoWatcher.Domain.Models
{
    public class Watcher : IAuditableEntity
    {
        public string Id => WatcherId.ToString();
        public int WatcherId { get; private set; }
        public string UserId { get; private set; }
        public string CurrencyId { get; private set; }
        public string IndicatorId { get; private set; }
        public IndicatorType IndicatorType { get; private set; }
        public decimal? Value { get; private set; }
        public decimal? Buy { get; private set; }
        public decimal? Sell { get; private set; }
        public decimal? AverageBuy { get; private set; }
        public decimal? AverageSell { get; private set; }
        public bool Enabled { get; private set; }
        public DateTime Time { get; private set; }

        public WatcherStatus Status => WatcherBuilder.BuildStatus(Value, Buy, Sell);

        public Watcher() { }
        public Watcher(
            string userId,
            string currencyId,
            string indicatorId,
            IndicatorType indicatortype,
            decimal? value,
            decimal? buy,
            decimal? sell,
            decimal? averageBuy,
            decimal? averageSell,
            bool enabled,
            DateTime time)
        {
            WatcherId = 0;
            UserId = userId;
            CurrencyId = currencyId;
            IndicatorId = indicatorId;
            IndicatorType = indicatortype;
            Value = value;
            Buy = buy;
            Sell = sell;
            AverageBuy = averageBuy;
            AverageSell = averageSell;
            Enabled = enabled;
            Time = time;
        }

        public Watcher Update(decimal buy, decimal sell, bool enabled)
        {
            Buy = buy;
            Sell = sell;
            Enabled = enabled;

            return this;
        }
        public Watcher Sync(decimal? value, decimal? averageBuy, decimal? averageSell)
        {
            Value = value;
            AverageBuy = averageBuy;
            AverageSell = averageSell;

            return this;
        }
    }
}
