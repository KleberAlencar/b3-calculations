namespace Calculation.Domain
{
    public class MonthlyCalculation
    {
        public MonthlyCalculation(int month, double initialValue, double finalValue)
        {
            Month = month;
            InitialValue = initialValue;
            FinalValue = finalValue;
        }

        public int Month { get; private set; }

        public double InitialValue { get; private set; }

        public double FinalValue { get; private set; }

        public double GrossIncome => Math.Round(FinalValue - InitialValue, 2);
    }
}