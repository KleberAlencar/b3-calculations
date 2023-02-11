using MediatR;
using Calculation.Domain;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Application.Queries.Requests
{
    public class GetCalculationRequest : IRequest<CdbCalculation>
    {
        [Required]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Investiment { get; set; }

        [Required]
        [Display(Name="Months Quantity")]
        [Range(2, 1200, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MonthsQuantity { get; set; }
    }
}