using MediatR;
using Calculation.Domain;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Application.Queries.Requests
{
    public class GetTaxDiscountRequest : IRequest<TaxDiscount>
    {
        [Required]
        [Range(1, Int16.MaxValue)]
        public int Id { get; set; }
    }
}