using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Calculation.Tests.Mock
{
    public class DataContextTest : IDataContext
    {
        public DataContextTest()
        {
            this.TaxDiscount = new TaxDiscountDbSetTest();
        }

        public DbSet<TaxDiscount> TaxDiscount { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}