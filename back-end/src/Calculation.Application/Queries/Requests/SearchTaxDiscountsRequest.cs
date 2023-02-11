using MediatR;
using Calculation.Domain;

namespace Calculation.Application.Queries.Requests
{
    public class SearchTaxDiscountsRequest : IRequest<List<TaxDiscount>>
    {        
    }
}