using System;


namespace XIRRCalculatorLib
{
    public class IncosistentCashFlowException : Exception
    {
    }

    public class InvalidCalculationException : Exception
    {
        public InvalidCalculationException(string message) : base(message)
        {
        }
    }
}
