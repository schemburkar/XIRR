using System;
using System.Collections.Generic;
using System.Linq;


namespace XIRRCalculatorLib
{
    public class CalculationWrapper
    {
        public static double XIRR(IEnumerable<CashFlow> cashflows, int decimals = 4, double maxRate = 1000000)
        {
            if (!cashflows.Any(x => x.Amount > 0))
            {
                throw new IncosistentCashFlowException();
            }
            if (!cashflows.Any(x => x.Amount < 0))
            {
                throw new IncosistentCashFlowException();
            }

            var precision = Math.Pow(10, -decimals);
            var minRate = -(1 - precision);
            return (new XIRRCalculator(minRate, maxRate, cashflows).Calculate(precision, decimals));
        }

    }
}
