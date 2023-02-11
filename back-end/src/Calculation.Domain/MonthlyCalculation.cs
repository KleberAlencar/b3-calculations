namespace Calculation.Domain
{
    public class MonthlyCalculation
    {
        public MonthlyCalculation(int month, double inicialValue, double finalValue)
        {
            Month = month;
            InitialValue = inicialValue;
            FinalValue = finalValue;
        }

        public int Month { get; private set; }

        public double InitialValue { get; private set; }

        public double FinalValue { get; private set; }
    }
}