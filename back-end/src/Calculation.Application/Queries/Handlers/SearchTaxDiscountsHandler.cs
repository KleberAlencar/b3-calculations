using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Entities;

namespace Calculation.Application.Queries.Handlers
{
    public class SearchTaxDiscountsHandler : IRequestHandler<SearchTaxDiscounts, List<TaxDiscount>>
    {
        private readonly DataContext _context;

        public SearchTaxDiscountsHandler(DataContext context)
        {
            _context = context;
            
        }

        public async Task<List<TaxDiscount>> Handle(SearchTaxDiscounts request, CancellationToken cancellationToken)
        {
            return await _context.TaxDiscount.ToListAsync();
        }
    }
}