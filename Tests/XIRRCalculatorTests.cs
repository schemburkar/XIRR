using System;

using System.Collections.Generic;
using XIRRCalculatorLib;
using Xunit;
namespace XIRRCalculatorLib.Tests
{

    public class XIRRCalculatorTests
    {
        [Fact]
        public void OneYearDeposit()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-1000, new DateTime(2017, 1, 1)),
                new CashFlowDates(1010, new DateTime(2018, 1, 1))
            };
            var result = CalculationWrapper.XIRR(cashFlows);
            Assert.Equal(0.01, result);
        }

        [Fact]
        public void OneYearDepositWithWithdrawal()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-1000, new DateTime(2017, 1, 1)),
                new CashFlowDates(500, new DateTime(2017, 7, 1)),
                new CashFlowDates(507.5, new DateTime(2018, 1, 1))
            };
            var result = CalculationWrapper.XIRR(cashFlows, 6);
            Assert.Equal(0.010019, result);
        }

        [Fact]
        public void StockInvestment()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-500, new DateTime(2017, 1, 1)),
                new CashFlowDates(-500, new DateTime(2017, 2, 1)),
                new CashFlowDates(-500, new DateTime(2017, 3, 1)),
                new CashFlowDates(-500, new DateTime(2017, 4, 1)),
                new CashFlowDates(-500, new DateTime(2017, 5, 1)),
                new CashFlowDates(-500, new DateTime(2017, 6, 1)),
                new CashFlowDates(-500, new DateTime(2017, 7, 1)),
                new CashFlowDates(-500, new DateTime(2017, 8, 1)),
                new CashFlowDates(-500, new DateTime(2017, 9, 1)),
                new CashFlowDates(-500, new DateTime(2017, 10, 1)),
                new CashFlowDates(-500, new DateTime(2017, 11, 1)),
                new CashFlowDates(-500, new DateTime(2017, 12, 1)),
                new CashFlowDates(6545.08, new DateTime(2018, 1, 1))
            };
            var result = CalculationWrapper.XIRR(cashFlows, 6);
            Assert.Equal(0.171156, result);
        }

        [Fact]
        public void NoPositiveCashFlows()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-1000, new DateTime(2017, 1, 1))
            };
            Assert.Throws<IncosistentCashFlowException>(() => CalculationWrapper.XIRR(cashFlows, 6));
        }

        [Fact]
        public void NoNegativeCashFlows()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(1000, new DateTime(2017, 1, 1))
            };

            Assert.Throws<IncosistentCashFlowException>(() => CalculationWrapper.XIRR(cashFlows, 6));
        }


        [Fact]
        public void FundInvestment()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-5000, new DateTime(2020, 2, 4)),
                new CashFlowDates(-15000, new DateTime(2020, 2, 17)),
                new CashFlowDates(-5000, new DateTime(2020, 3, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 4, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 5, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 6, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 7, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 8, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 9, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 10, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 11, 4)),
                new CashFlowDates(-5000, new DateTime(2020, 12, 4)),
                new CashFlowDates(-5000, new DateTime(2021, 1, 4)),
                new CashFlowDates(-5000, new DateTime(2021, 2, 4)),
                new CashFlowDates(-5000, new DateTime(2021, 3, 4)),
                new CashFlowDates(-5000, new DateTime(2021, 4, 4)),
                new CashFlowDates(-5000, new DateTime(2021, 5, 4)),
                new CashFlowDates(120831, new DateTime(2021, 5, 21))
            };
            var result = CalculationWrapper.XIRR(cashFlows, 4);
            Assert.Equal(0.3569, result);
        }

        [Fact]
        public void FundInvestmentWithWidrawl()
        {
            var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-2000, new DateTime(2018, 04, 3)),
                new CashFlowDates(-1500, new DateTime(2018, 05, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 06, 7)),
                new CashFlowDates(-10000, new DateTime(2018, 06, 12)),
                new CashFlowDates(-1500, new DateTime(2018, 07, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 08, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 09, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 10, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 11, 7)),
                new CashFlowDates(-1500, new DateTime(2018, 12, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 01, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 02, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 03, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 04, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 05, 7)),
                new CashFlowDates(-1500, new DateTime(2019, 06, 7)),
                new CashFlowDates(4000, new DateTime(2021, 04, 19)),
                new CashFlowDates(4000, new DateTime(2021, 05, 19)),
                new CashFlowDates(41875, new DateTime(2021, 05, 21))
            };
            var result = CalculationWrapper.XIRR(cashFlows, 4);
            Assert.Equal(0.1671, result);
        }

    }
}
