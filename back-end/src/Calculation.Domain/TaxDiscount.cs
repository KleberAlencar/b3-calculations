namespace Calculation.Domain
{
    public class TaxDiscount
    {
        public TaxDiscount(int startingMonth, int endingMonth, double percentage)
        {
            StartingMonth = startingMonth;
            EndingMonth = endingMonth;
            Percentage = percentage;
        }

        public int Id { get; private set; }

        public int StartingMonth { get; private set; }

        public int EndingMonth { get; private set; }

        public double Percentage { get; private set; }
    }
}