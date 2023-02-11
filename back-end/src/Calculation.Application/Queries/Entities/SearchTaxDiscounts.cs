using MediatR;
using Calculation.Domain;

namespace Calculation.Application.Queries.Entities
{
    public class SearchTaxDiscounts : IRequest<List<TaxDiscount>>
    {        
    }
}