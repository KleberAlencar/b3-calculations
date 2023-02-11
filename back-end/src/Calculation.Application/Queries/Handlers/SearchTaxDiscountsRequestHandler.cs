using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class SearchTaxDiscountsRequestHandler : IRequestHandler<SearchTaxDiscountsRequest, List<TaxDiscount>>
    {
        private readonly DataContext _context;

        public SearchTaxDiscountsRequestHandler(DataContext context)
        {
            _context = context;
            
        }

        public async Task<List<TaxDiscount>> Handle(SearchTaxDiscountsRequest request, CancellationToken cancellationToken)
        {
            return await _context.TaxDiscount.ToListAsync();
        }
    }
}