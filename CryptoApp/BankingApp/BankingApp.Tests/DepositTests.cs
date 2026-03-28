using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Tests
{
    public class DepositCalculatorTests
    {
        private readonly DepositCalculator _calc = new DepositCalculator();

        [Fact]
        public void Calculate_ReturnsMoreThanInitial()
        {
            var result = _calc.Calculate(1000m, 12, 0.12m);

            Assert.True(result > 1000m);
        }
    }
}
