﻿using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using Hyper.Domain.Repositories;
using Hyper.Infrastructure.Mappings;
using NoobsMuc.Coinmarketcap.Client;
using Hyper.Infrastructure.Contexts;

namespace Hyper.Infrastructure.Jobs
{
    public class ImportCurrenciesJob
    {
        readonly ILogger<ImportCurrenciesJob> _logger;
        private readonly MainDbContext _mainDbContext;
        private readonly ICoinmarketcapClient _coinmarketcapClient;
        private readonly ICurrencyRepository _currencyRepository;

        public ImportCurrenciesJob(ILogger<ImportCurrenciesJob> logger, MainDbContext mainDbContext, ICoinmarketcapClient coinmarketcapClient, ICurrencyRepository currencyRepository)
        {
            _logger = logger;
            _mainDbContext = mainDbContext;
            _coinmarketcapClient = coinmarketcapClient;
            _currencyRepository = currencyRepository;
        }

        [Queue("Hyper")]
        [AutomaticRetry(OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        public async Task Run()
        {
            try
            {
                // Get all currencies from CoinMarketCap
                var result = _coinmarketcapClient.GetCurrencies();

                // Map to our Model
                var currencies = result.Map();

                // Set all currencies
                await _currencyRepository.SetAllCurrencies(currencies);

                // Save
                await _mainDbContext.SaveChangesAsync();

                // Log into Splunk
                _logger.LogInformation("Event=ImportCountriesCompleted");
            }
            catch (Exception ex)
            {
                // Log into Splunk
                _logger.LogError(ex, "Event=ImportCountriesFailed");
            }
        }
    }
}