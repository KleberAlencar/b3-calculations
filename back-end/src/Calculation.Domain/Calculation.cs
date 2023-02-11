namespace Calculation.Domain
{
    public class Calculation
    {
        private IList<MonthlyCalculation> _monthlyCalculations;

        public Calculation(double initialValue, double grossValue, double netValue)
        {
            InitialValue = initialValue;
            GrossValue = grossValue;
            NetValue = netValue;
            _monthlyCalculations = new List<MonthlyCalculation>();
        }

        public double InitialValue { get; private set; }

        public double GrossValue { get; private set; }

        public double NetValue { get; private set; }

        public IReadOnlyCollection<MonthlyCalculation> MonthlyCalculations { get; set; }
    }
}