using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals_API_DotNet.Controllers.API;
using RomanNumerals_API_DotNet.Data;
using RomanNumerals_API_DotNet.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals_API_DotNet.Tests
{
    [TestClass]
    public class IntegerConversionTests
    {
        private ApplicationDbContext context;
        private IConversionAnalyticsService conversionAnalyticsService;

        private IIntegerConversionService integerConversionService;
        private ConvertToNumeralController convertToNumeralController;
        private RecentConversionsController recentConversionsController;
        private TopConversionsController topConversionsController;

        [TestInitialize]
        public void TestInitialize()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Use separate database here as this is intended for unit tests only
            optionBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=RomanNumerals.Test;Integrated Security=True");

            context = new ApplicationDbContext(optionBuilder.Options);
            conversionAnalyticsService = new ConversionAnalyticsServiceFake(context);

            integerConversionService = new IntegerConversionServiceFake();
            convertToNumeralController = new ConvertToNumeralController(integerConversionService, conversionAnalyticsService);
            recentConversionsController = new RecentConversionsController(conversionAnalyticsService);
            topConversionsController = new TopConversionsController(conversionAnalyticsService);
        }

        [TestMethod]
        public void ConvertsCorrectly()
        {
            var cases = new List<(int value, string expected)>()
            {
                (1, "I"),
                (4, "IV"),
                (5, "V"),
                (9, "IX"),
                (10, "X"),
                (100, "C"),
                (40, "XL"),
                (50, "L"),
                (90, "XC"),
                (400, "CD"),
                (500, "D"),
                (900, "CM"),
                (1000, "M")
            };

            foreach (var testCase in cases)
            {
                var actual = integerConversionService.ToRomanNumerals(testCase.value);
                Assert.AreEqual(actual, testCase.expected);
            }
        }

        [TestMethod]
        public void ConvertsSomeSpecialCases()
        {
            var actual = integerConversionService.ToRomanNumerals(3999);
            Assert.AreEqual(actual, "MMMCMXCIX");

            actual = integerConversionService.ToRomanNumerals(2016);
            Assert.AreEqual(actual, "MMXVI");

            actual = integerConversionService.ToRomanNumerals(2018);
            Assert.AreEqual(actual, "MMXVIII");
        }

        [TestMethod]
        public void Get_OkResult()
        {
            var number = 1;

            var result = convertToNumeralController.Get(number) as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_RomanNumeral3999()
        {
            var number = 3999;

            var result = convertToNumeralController.Get(number) as OkObjectResult;
            var expected = "MMMCMXCIX";
            var actual = result.Value as string;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RomanNumeralNegative_BadResult()
        {
            var number = -1;

            var result = convertToNumeralController.Get(number) as BadRequestObjectResult;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void RomanNumeral4k_BadResult()
        {
            var number = 40000;

            var result = convertToNumeralController.Get(number) as BadRequestObjectResult;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Get_Logs()
        {
            var result = recentConversionsController.GetLogs() as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_Top10()
        {
            var result = topConversionsController.GetTop10() as OkObjectResult;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
