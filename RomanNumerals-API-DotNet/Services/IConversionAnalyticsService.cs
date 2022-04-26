using RomanNumerals_API_DotNet.Models;
using System.Collections.Generic;

namespace RomanNumerals_API_DotNet.Services
{
    public interface IConversionAnalyticsService
    {
        void LogConversion(int number, string romanNumeralCounterpart);

        List<ConversionLog> GetConversionLogs();

        List<ConversionLogViewModel> GetTop10ConversionLogs();
    }
}
