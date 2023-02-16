namespace Calculation.Domain
{
    public class CdbCalculation
    {
        #region [ Attributes ]

        private IList<MonthlyCalculation> _monthlyCalculations;

        #endregion

        #region [ Constructors ]

        public CdbCalculation()
        {            
        }

        public CdbCalculation(double investiment, double grossIncome, double netIncome, double taxDiscountValue)
        {
            Investiment = investiment;
            GrossIncome = grossIncome;
            NetIncome = netIncome;
            TaxDiscountValue = taxDiscountValue;
            _monthlyCalculations = new List<MonthlyCalculation>();
        }

        #endregion

        #region [ Properties ]

        public double Investiment { get; private set; }

        public double GrossIncome { get; private set; }

        public double NetIncome { get; private set; }

        public double TaxDiscountValue { get; private set; }

        public double TotalGrossInvestmentValue => Investiment + GrossIncome;

        public double TotalNetInvestmentValue => Investiment + NetIncome;

        public IReadOnlyCollection<MonthlyCalculation> MonthlyCalculations { get { return _monthlyCalculations.ToArray(); } }

        #endregion

        #region [ Public Methods ]

        public void AddMonthyCalculation(MonthlyCalculation monthlyCalculation)
        {
            _monthlyCalculations.Add(monthlyCalculation);
        }

        public void UpdateGrossIncome(double grossValue)
        {
            GrossIncome = Math.Round(grossValue, 2);
        }

        public void UpdateNetIncome(double netValue)
        {
            NetIncome = Math.Round(netValue, 2);
        }

        public void UpdateTaxDiscountValue(double taxDiscountValue)
        {
            TaxDiscountValue = Math.Round(taxDiscountValue, 2);
        }

        #endregion
    }
}