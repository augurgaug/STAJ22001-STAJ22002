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
            return CreatedAtAction(nameof(GetFinanceById), new { id = newFinance.id }, newFinance);
        }

        [HttpGet]
        public async Task<ActionResult<List<Finance>>> GetFinanceById()
        {
            var finances = await _financeService.GetFinances();
            return Ok(finances);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Finance>> GetPaymentById(int id)
        {
            var finance = await _financeService.GetFinanceById(id);
            if (finance == null)
            {
                return NotFound();
            }
            return Ok(finance);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetFinancesCount()
        {
            var count = await _financeService.GetFinancesCount();
            return Ok(count);
        }
        [HttpGet("count/nakitodeme")]
        public async Task<ActionResult<int>> GetFinancesNOCount()
        {
            var count = await _financeService.GetFinancesNOCount();
            return Ok(count);
        }
        [HttpGet("count/nakittahsilat")]
        public async Task<ActionResult<int>> GetFinancesNTCount()
        {
            var count = await _financeService.GetFinancesNTCount();
            return Ok(count);
        }
        [HttpGet("count/gidenhavale")]
        public async Task<ActionResult<int>> GetFinancesGiHCount()
        {
            var count = await _financeService.GetFinancesGiHCount();
            return Ok(count);
        }
        [HttpGet("count/gelenhavale")]
        public async Task<ActionResult<int>> GetFinancesGeHCount()
        {
            var count = await _financeService.GetFinancesGeHCount();
            return Ok(count);
        }
        [HttpGet("count/postahsilat")]
        public async Task<ActionResult<int>> GetFinancesPTCount()
        {
            var count = await _financeService.GetFinancesPTCount();
            return Ok(count);
        }
        [HttpGet("count/kkodeme")]
        public async Task<ActionResult<int>> GetFinancesKKCount()
        {
            var count = await _financeService.GetFinancesKKCount();
            return Ok(count);
        }


    }
}
