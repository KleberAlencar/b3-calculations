using MediatR;
using Calculation.Domain;
using Calculation.Application.Queries.Requests;

namespace Calculation.Application.Queries.Handlers
{
    public class GetCalculationRequestHandler : IRequestHandler<GetCalculationRequest, CdbCalculation>
    {
        public async Task<CdbCalculation> Handle(GetCalculationRequest request, CancellationToken cancellationToken)
        {
            var initialValue = request.Investiment;
            var finalValue = 0.00;

            var cdbCalculation = new CdbCalculation(initialValue, 0, 0);

            for (int i = 0; i < request.MonthsQuantity; i++)
            {
                finalValue = Math.Round(initialValue * (1 + (0.009 * 1.08)), 2);
                cdbCalculation.AddMonthyCalculation(new MonthlyCalculation(i + 1, initialValue, finalValue));
                initialValue = finalValue;
            }

            cdbCalculation.UpdateGrossValue(finalValue);

            return cdbCalculation;
        }
    }
}