namespace Calculation.Domain
{
    public class CdbCalculation
    {
        private IList<MonthlyCalculation> _monthlyCalculations;

        public CdbCalculation(double investiment, double grossValue, double netValue)
        {
            Investiment = investiment;
            GrossValue = grossValue;
            NetValue = netValue;
            _monthlyCalculations = new List<MonthlyCalculation>();
        }

        public double Investiment { get; private set; }

        public double GrossValue { get; private set; }

        public double NetValue { get; private set; }

        public IReadOnlyCollection<MonthlyCalculation> MonthlyCalculations { get { return _monthlyCalculations.ToArray(); } }

        public void AddMonthyCalculation(MonthlyCalculation monthlyCalculation)
        {
            _monthlyCalculations.Add(monthlyCalculation);
        }

        public void UpdateGrossValue(double grossValue)
        {
            GrossValue = grossValue;
        }
    }
}