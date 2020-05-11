﻿using System;
using CesarBmx.Shared.Domain.Models;


namespace CryptoWatcher.Domain.Models
{
    public class IndicatorDependency: IEntity
    {
        public string Id => IndicatorId + "_" + DependencyId;
        public string IndicatorId { get; private set; }
        public string DependencyId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IndicatorDependency() { }
        public IndicatorDependency(string indicatorId, string dependencyId, DateTime createdAt)
        {
            IndicatorId = indicatorId;
            DependencyId = dependencyId;
            CreatedAt = createdAt;
        }
    }
}
