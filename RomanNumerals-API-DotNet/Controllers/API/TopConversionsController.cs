using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals_API_DotNet.Services;

namespace RomanNumerals_API_DotNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopConversionsController : ControllerBase
    {
        private readonly IConversionAnalyticsService ConversionAnalyticsService;

        public TopConversionsController(IConversionAnalyticsService conversionAnalyticsService)
        {
            ConversionAnalyticsService = conversionAnalyticsService;
        }

        [HttpGet]
        public IActionResult GetTop10()
        {
            return Ok(ConversionAnalyticsService.GetTop10ConversionLogs());
        }
    }
}
