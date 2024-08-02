using MyApi.Business.FinanceServ;
using MyApi.Finances;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Finances
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly FinanceService _financeService;

        public FinanceController(FinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost]
        public async Task<ActionResult<Finance>> AddFinance(Finance finance)
        {
            var newFinance = await _financeService.AddFinance(finance);
            if (newFinance == null)
            {
                return BadRequest(new { message = "Ýþlem bulunamadý." });
            }
            return CreatedAtAction(nameof(GetFinanceById), new { id = newFinance.FinanceId }, newFinance);
        }

        [HttpGet]
        public async Task<ActionResult<List<Finance>>> GetFinanceById()
        {
            var finances = await _financeService.GetFinances();
            return Ok(finances);
        }

       
    }
}
