using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Calculation.Application.Core;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class GetTaxDiscountRequestHandler : IRequestHandler<GetTaxDiscountRequest, Result<TaxDiscount>>
    {
        private readonly IDataContext _context;

        public GetTaxDiscountRequestHandler(IDataContext context)
        {
            _context = context;
        }

        public async Task<Result<TaxDiscount>> Handle(GetTaxDiscountRequest request, CancellationToken cancellationToken)
        {
            var discounts = await _context.TaxDiscount.ToListAsync();
            var taxDiscount = discounts.Where(x => x.StartingMonth <= request.Month && x.EndingMonth >= request.Month).FirstOrDefault();

            return Result<TaxDiscount>.Success(taxDiscount);
        }
    }
}