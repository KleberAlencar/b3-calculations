using MediatR;
using Calculation.Domain;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class GetCalculationRequestHandler : IRequestHandler<GetCalculationRequest, CdbCalculation>
    {
        private readonly DataContext _context;

        public GetCalculationRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<CdbCalculation> Handle(GetCalculationRequest request, CancellationToken cancellationToken)
        {           
            var initialValue = request.Investiment;
            var finalValue = 0.00;

            var cdbCalculation = new CdbCalculation(initialValue, 0, 0, 0);

            for (int i = 0; i < request.MonthsQuantity; i++)
            {
                finalValue = Math.Round(initialValue * (1 + (0.009 * 1.08)), 2);
                cdbCalculation.AddMonthyCalculation(new MonthlyCalculation(i + 1, initialValue, finalValue));
                initialValue = finalValue;
            }

            var taxDiscount = await _context.TaxDiscount.FirstOrDefaultAsync(x => x.StartingMonth <= request.MonthsQuantity && 
                                                                                  x.EndingMonth >= request.MonthsQuantity);
            if (taxDiscount != null)
            {
                var taxDiscountValue = Math.Round((finalValue - request.Investiment) * (taxDiscount.Percentage / 100), 2);
                var netValue = Math.Round((finalValue - request.Investiment) - taxDiscountValue, 2);

                cdbCalculation.UpdateNetIncome(netValue);
                cdbCalculation.UpdateGrossIncome(Math.Round(finalValue - request.Investiment, 2));
                cdbCalculation.UpdateTaxDiscountValue(taxDiscountValue);
            }

            return cdbCalculation;
        }
    }
}