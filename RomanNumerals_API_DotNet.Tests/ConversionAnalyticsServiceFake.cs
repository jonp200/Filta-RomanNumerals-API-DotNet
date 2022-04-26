using RomanNumerals_API_DotNet.Data;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals_API_DotNet.Tests
{
    internal class ConversionAnalyticsServiceFake : ConversionAnalyticsService
    {
        public ConversionAnalyticsServiceFake(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
