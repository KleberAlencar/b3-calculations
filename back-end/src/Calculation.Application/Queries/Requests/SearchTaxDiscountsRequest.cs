using MediatR;
using Calculation.Domain;
using Calculation.Application.Core;

namespace Calculation.Application.Queries.Requests
{
    public class SearchTaxDiscountsRequest : IRequest<Result<List<TaxDiscount>>>
    {        
    }
}