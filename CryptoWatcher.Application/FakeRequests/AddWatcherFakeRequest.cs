﻿using CryptoWatcher.Application.Requests;



namespace CryptoWatcher.Application.FakeRequests
{
    public static class AddWatcherFakeRequest
    {
        public static AddWatcherRequest GetFake_1()
        {
            return new AddWatcherRequest
            {
                UserId = "johny.melavo",
                CurrencyId = "bitcoin",
                IndicatorId = "johny.melavo-hype",
                Buy = 8m,
                Sell = 2m,
                Enabled = true
            };
        }       
    }
}