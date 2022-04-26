using System;

namespace RomanNumerals_API_DotNet.Models
{
    public class ConversionLog
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string RomanNumeralCounterpart { get; set; }

        public DateTime Requested { get; set; }
    }
}
