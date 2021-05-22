using System;

using System.Collections.Generic;
using Klear.Financial.Lib;
using Xunit;
namespace Tests
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

    }
}
