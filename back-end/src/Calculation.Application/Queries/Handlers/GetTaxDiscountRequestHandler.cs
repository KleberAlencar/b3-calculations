using MediatR;
using System.Linq;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class GetTaxDiscountRequestHandler : IRequestHandler<GetTaxDiscountRequest, TaxDiscount>
    {
        private readonly DataContext _context;

        public GetTaxDiscountRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<TaxDiscount> Handle(GetTaxDiscountRequest request, CancellationToken cancellationToken)
        {
            return await _context.TaxDiscount.FirstOrDefaultAsync(x => x.StartingMonth <= request.Month && x.EndingMonth >= request.Month);
        }
    }
}