using Calculation.Domain;
using Microsoft.AspNetCore.Mvc;
using Calculation.Application.Queries.Entities;
using Calculation.Api.Controllers.Base;

namespace Calculation.Api.Controllers
{
    [Route("api/calculations")]
    public class CalculationController : BaseApiController
    {
        [HttpGet]
        [Route("tax-discounts")]
        public async Task<ActionResult<List<TaxDiscount>>> Search()
        {
            return await Mediator.Send(new SearchTaxDiscounts());
        }

        [HttpGet]
        [Route("tax-discounts/{id}")]
        public async Task<ActionResult<TaxDiscount>> Get(int id)
        {
            return await Mediator.Send(new GetTaxDiscount{Id = id});
        }
    }
}