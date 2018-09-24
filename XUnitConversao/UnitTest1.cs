using System;
using Xunit;
using Conversao.Controllers;

namespace XUnitConversao
{
    public class UnitTest1
    {
        private readonly ConversionController _conversionController;
       
        [Fact]
        public void Test1()
        {
            var result = _conversionController.currenciesList();
            Assert.False(result.success, "Lista não retornada");
        }

        [Fact]
        public void Test2()
        {
            var result = _conversionController.currencyLive("USD", "BRL");
            Assert.False(result.success, "Lista não retornada");
        }

        [Fact]
        public void Test3()
        {
            var result = _conversionController.currencyLive("USB", "BRT");
            Assert.False(result.success, "Lista não retornada");
        }
    }
}
