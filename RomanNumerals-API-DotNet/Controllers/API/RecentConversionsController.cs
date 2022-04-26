using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Services;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecentConversionsController : ControllerBase
    {
        private readonly IConversionAnalyticsService ConversionAnalyticsService;

        public RecentConversionsController(IConversionAnalyticsService conversionAnalyticsService)
        {
            ConversionAnalyticsService = conversionAnalyticsService;
        }

        [HttpGet]
        public IActionResult GetLogs()
        {
            return Ok(ConversionAnalyticsService.GetConversionLogs());
        }
    }
}
