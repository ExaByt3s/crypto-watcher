﻿using System;
using CryptoWatcher.Domain.Types;


namespace CryptoWatcher.Domain.Builders
{
    public static class NotificationBuilder
    {
        public static NotificationStatus BuildNotificationStatus(DateTime? sentTime)
        {
            if (sentTime.HasValue) return NotificationStatus.Notified;
            return NotificationStatus.Pending;
        }
    }
}
