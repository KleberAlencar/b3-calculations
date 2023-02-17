using Calculation.Domain;
using Microsoft.EntityFrameworkCore;

namespace Calculation.Infrastructure
{
    public interface IDataContext : IDisposable
    {
        DbSet<TaxDiscount> TaxDiscount { get; set; }
    }
}