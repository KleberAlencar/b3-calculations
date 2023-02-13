using MediatR;
using System.Linq;
using Calculation.Domain;
using Calculation.Infrastructure;
using Calculation.Application.Core;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class GetTaxDiscountRequestHandler : IRequestHandler<GetTaxDiscountRequest, Result<TaxDiscount>>
    {
        private readonly DataContext _context;

        public GetTaxDiscountRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<TaxDiscount>> Handle(GetTaxDiscountRequest request, CancellationToken cancellationToken)
        {
            var taxDiscount = await _context.TaxDiscount.FirstOrDefaultAsync(x => x.StartingMonth <= request.Month && x.EndingMonth >= request.Month);
            return Result<TaxDiscount>.Success(taxDiscount);
        }
    }
}