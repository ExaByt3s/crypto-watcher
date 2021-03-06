﻿using System;
using System.Collections.Generic;
using System.Linq;
using CryptoWatcher.Domain.Expressions;
using CryptoWatcher.Domain.Models;
using CryptoWatcher.Domain.Types;


namespace CryptoWatcher.Domain.Builders
{
    public static class OrderBuilder
    {
        public static List<Order> BuildNewOrders(List<Watcher> watchers, List<Order> ongoingOrders)
        {
            // Now
            var now = DateTime.Now;

            var newOrders = new List<Order>();

            foreach (var watcher in watchers)
            {
                // We skip default watchers
                if(watcher.UserId == "master") continue;

                // We add an order if there are no similar orders
                var orderType = BuildOrderType(watcher.Status);
                var userOrders = ongoingOrders.Where(OrderExpression.Order(
                    watcher.UserId,
                    watcher.CurrencyId,
                    orderType).Compile()).ToList();                
                if (userOrders.Count != 0) continue;
                var order = new Order(watcher.UserId, orderType, watcher.CurrencyId, 100, now);
                newOrders.Add(order);
            }

            // Return
            return newOrders;
        }
        public static OrderType BuildOrderType(WatcherStatus watcherStatus)
        {
            switch (watcherStatus)
            {
                case WatcherStatus.Buy:
                    return OrderType.BuyLimit;
                case WatcherStatus.Sell:
                    return OrderType.SellMarket;
                default:
                    throw new ArgumentOutOfRangeException(nameof(watcherStatus), watcherStatus, null);
            }
        }
    }
}
