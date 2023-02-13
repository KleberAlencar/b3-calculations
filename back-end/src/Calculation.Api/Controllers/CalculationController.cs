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
        public async Task<IActionResult> GetCdbCalculation([FromQuery]GetCalculationRequest request)
        {
            return HandleResult(await Mediator.Send(request));
        }

        [HttpGet]
        [Route("tax-discounts/ranges")]
        public async Task<IActionResult> GetTaxDiscount([FromQuery] GetTaxDiscountRequest request)
        {
            return HandleResult(await Mediator.Send(request));
        }

        [HttpGet]
        [Route("tax-discounts")]
        public async Task<IActionResult> SearchTaxDiscounts()
        {
            return HandleResult(await Mediator.Send(new SearchTaxDiscountsRequest()));
        }
    }
}