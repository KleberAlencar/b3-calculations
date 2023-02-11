using Calculation.Domain;
using Microsoft.AspNetCore.Mvc;
using Calculation.Api.Controllers.Base;
using Calculation.Application.Queries.Requests;

namespace Calculation.Api.Controllers
{
    [Route("api/calculations")]
    public class CalculationController : BaseApiController
    {
        [HttpGet]
        [Route("cdb")]
        public async Task<ActionResult<CdbCalculation>> GetCdbCalculation([FromQuery]GetCalculationRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet]
        [Route("tax-discounts")]
        public async Task<ActionResult<List<TaxDiscount>>> Search()
        {
            return await Mediator.Send(new SearchTaxDiscountsRequest());
        }

        [HttpGet]
        [Route("tax-discounts/{id}")]
        public async Task<ActionResult<TaxDiscount>> Get(int id)
        {
            return await Mediator.Send(new GetTaxDiscountRequest{Id = id});
        }
    }
}