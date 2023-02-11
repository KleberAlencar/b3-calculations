using System.ComponentModel.DataAnnotations;

namespace Calculation.Application.Queries.Entities
{
    public class SearchCdbCalculation
    {
        [Required]
        [Range(2, Int32.MaxValue)]
        public int MonthsQuantity { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity)]
        public double MonetaryValue { get; set; }
    }
}