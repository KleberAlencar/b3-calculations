namespace Calculation.Tests.Mock.Entities
{
    public class TaxDiscount
    {
        public int Id { get; set; }

        public int StartingMonth { get; set; }

        public int EndingMonth { get; set; }

        public double Percentage { get; set; }
    }
}