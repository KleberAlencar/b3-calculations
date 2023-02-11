namespace Calculation.Domain
{
    public class MonthlyCalculation
    {
        public MonthlyCalculation(int month, double referenceValue, double calculatedGrossValue)
        {
            Month = month;
            ReferenceValue = referenceValue;
            CalculatedGrossValue = calculatedGrossValue;
        }

        public int Month { get; private set; }

        public double ReferenceValue { get; private set; }

        public double CalculatedGrossValue { get; private set; }
    }
}