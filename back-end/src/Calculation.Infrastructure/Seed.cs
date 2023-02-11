using Calculation.Domain;

namespace Calculation.Infrastructure
{
    public class Seed
    {
        
        public static async Task SeedData(DataContext context)
        {
            if (context.TaxDiscount.Any()) return;
            
            var discounts = new List<TaxDiscount>();
            discounts.Add(new TaxDiscount(1, 6, 22.5));
            discounts.Add(new TaxDiscount(7, 12, 20));
            discounts.Add(new TaxDiscount(13, 24, 17.5));
            discounts.Add(new TaxDiscount(24, 9999, 15));

            await context.TaxDiscount.AddRangeAsync(discounts);
            await context.SaveChangesAsync();
        }

    }
}