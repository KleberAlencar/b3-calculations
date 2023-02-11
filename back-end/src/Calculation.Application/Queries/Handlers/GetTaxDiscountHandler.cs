using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Calculation.Application.Queries.Entities;

namespace Calculation.Application.Queries.Handlers
{
    public class GetTaxDiscountHandler : IRequestHandler<GetTaxDiscount, TaxDiscount>
    {
        private readonly DataContext _context;

        public GetTaxDiscountHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<TaxDiscount> Handle(GetTaxDiscount request, CancellationToken cancellationToken)
        {
            return await _context.TaxDiscount.FindAsync(request.Id);
        }
    }
}