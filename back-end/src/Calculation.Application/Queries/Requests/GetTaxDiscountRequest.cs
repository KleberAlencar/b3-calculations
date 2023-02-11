using MediatR;
using Calculation.Domain;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Application.Queries.Requests
{
    public class GetTaxDiscountRequest : IRequest<TaxDiscount>
    {
        [Required]
        [Range(1, 1200, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Month { get; set; }
    }
}