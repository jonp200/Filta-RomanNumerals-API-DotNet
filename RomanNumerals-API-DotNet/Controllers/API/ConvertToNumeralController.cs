using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Services;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertToNumeralController : ControllerBase
    {
        private readonly IIntegerConversionService IntegerConversionService;
        private readonly IConversionAnalyticsService ConversionAnalyticsService;

        public ConvertToNumeralController(IIntegerConversionService integerConversionService,
            IConversionAnalyticsService conversionAnalyticsService)
        {
            IntegerConversionService = integerConversionService;
            ConversionAnalyticsService = conversionAnalyticsService;
        }

        [HttpGet]
        public IActionResult Get(int number)
        {
            if (number < 0 || number > 3999)
                return BadRequest("This API only supports integers ranging from 1 to 3999");

            var result = IntegerConversionService.ToRomanNumerals(number);

            ConversionAnalyticsService.LogConversion(number, result);

            return Ok(result);
        }
    }
}