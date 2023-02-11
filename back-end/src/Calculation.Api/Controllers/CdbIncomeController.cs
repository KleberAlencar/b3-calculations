using Calculation.Domain;
using Microsoft.AspNetCore.Mvc;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Api.Controllers.Base;

namespace Calculation.Api.Controllers
{
    [Route("api/calculations")]
    public class CdbIncomeController : BaseApiController
    {
        private readonly DataContext _context;

        public CdbIncomeController(DataContext context)
        {
            _context = context;            
        }

        [HttpGet]
        [Route("tax-discounts")]
        public async Task<ActionResult<List<TaxDiscount>>> Search()
        {
            return await _context.TaxDiscount.ToListAsync();
        }

        [HttpGet]
        [Route("tax-discounts/{id}")]
        public async Task<ActionResult<TaxDiscount>> Get(int id)
        {
            return await _context.TaxDiscount.FindAsync(id);
        }
    }
}