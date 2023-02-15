using Calculation.Domain;
using Microsoft.EntityFrameworkCore;

namespace Calculation.Infrastructure
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaxDiscount> TaxDiscount { get; set; }
    }
}