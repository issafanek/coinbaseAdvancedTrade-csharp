﻿using System;

namespace CoinbaseAdvancedTrade.Shared.Utilities.Clock
{
    public class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}
