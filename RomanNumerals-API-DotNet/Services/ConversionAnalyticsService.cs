using RomanNumerals_API_DotNet.Data;
using RomanNumerals_API_DotNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals_API_DotNet.Services
{
    public class ConversionAnalyticsService : IConversionAnalyticsService
    {
        private readonly ApplicationDbContext DbContext;

        public ConversionAnalyticsService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<ConversionLog> GetConversionLogs()
        {
            // Return all records since there is limit count indicated in the specifications
            return DbContext.ConversionLogs.OrderByDescending(c => c.Id).ToList();
        }

        public List<ConversionLogViewModel> GetTop10ConversionLogs()
        {
            return DbContext.ConversionLogs
                .GroupBy(c => c.Number)
                .Select(c => new ConversionLogViewModel
                {
                    Number = c.Key,
                    ConversionCount = c.Count()
                })
                .OrderByDescending(c => c.ConversionCount)
                .Take(10)
                .ToList();
        }

        public void LogConversion(int number, string romanNumeralCounterpart)
        {
            try
            {
                var log = new ConversionLog
                {
                    Number = number,
                    RomanNumeralCounterpart = romanNumeralCounterpart,
                    Requested = System.DateTime.UtcNow
                };

                DbContext.ConversionLogs.Add(log);

                DbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
