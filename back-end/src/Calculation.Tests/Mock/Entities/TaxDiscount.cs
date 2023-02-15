namespace Calculation.Tests.Mock.Entities
{
    public class TaxDiscount
    {
        public int Id { get; private set; }

        public int StartingMonth { get; private set; }

        public int EndingMonth { get; private set; }

        public double Percentage { get; private set; }
    }
}