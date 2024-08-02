using Microsoft.AspNetCore.Mvc;

using MyApi.Business.CariServ;
using MyApi.Caris;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Caris
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarisController : ControllerBase
    {
        private readonly CariService _cariService;

        public CarisController(CariService cariService)
        {
            _cariService = cariService;
        }



        [HttpPost]
        public async Task<ActionResult<Cari>> PostCari(Cari cari)
        {
            var newCari = await _cariService.PostCari(cari);
            if (newCari == null)
            {
                return Conflict(new { message = "asd!" });
            }
            return CreatedAtAction("GetCari", new { id = newCari.CariId }, newCari);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cari>> GetCari(int id)
        {
            var cari = await _cariService.GetCari(id);
            if (cari == null)
            {
                return NotFound();
            }
            return Ok(cari);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cari>>> GetCaris()
        {
            var caris = await _cariService.GetCaris();
            return Ok(caris);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCari(int id)
        {
            var result = await _cariService.DeleteCari(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("carii/{id}")]
        public async Task<IActionResult> UpdateCarii(int id, Cari updatedCarii)
        {
            var result = await _cariService.UpdateCarii(id, updatedCarii);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCari(int id, Cari updatedCari)
        {
            var result = await _cariService.UpdateCari(id, updatedCari);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}