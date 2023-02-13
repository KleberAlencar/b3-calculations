using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Calculation.Application.Core;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class SearchTaxDiscountsRequestHandler : IRequestHandler<SearchTaxDiscountsRequest, Result<List<TaxDiscount>>>
    {
        private readonly DataContext _context;

        public SearchTaxDiscountsRequestHandler(DataContext context)
        {
            _context = context;
            
        }

        public async Task<Result<List<TaxDiscount>>> Handle(SearchTaxDiscountsRequest request, CancellationToken cancellationToken)
        {
            return Result<List<TaxDiscount>>.Success(await _context.TaxDiscount.ToListAsync());
        }
    }
}