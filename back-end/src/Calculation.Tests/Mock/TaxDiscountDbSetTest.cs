using Calculation.Domain;

namespace Calculation.Tests.Mock
{
    public class TaxDiscountDbSetTest : DbSetTest<TaxDiscount>
    {
        public override TaxDiscount Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int)keyValues.Single());
        }
    }
}