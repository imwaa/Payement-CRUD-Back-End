using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayementApi.Models;

namespace PayementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementDetailController : ControllerBase
    {
        private readonly PayementDetailContext _context;

        public PayementDetailController(PayementDetailContext context)
        {
            _context = context;
        }

        // GET: api/PayementDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayementDetail>>> GetPayementDetails()
        {
            return await _context.PayementDetails.ToListAsync();
        }

        // GET: api/PayementDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayementDetail>> GetPayementDetail(int id)
        {
            var payementDetail = await _context.PayementDetails.FindAsync(id);

            if (payementDetail == null)
            {
                return NotFound();
            }

            return payementDetail;
        }

        // PUT: api/PayementDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayementDetail(int id, PayementDetail payementDetail)
        {
            if (id != payementDetail.PayementDetailId)
            {
                return BadRequest();
            }

            _context.Entry(payementDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayementDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PayementDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayementDetail>> PostPayementDetail(PayementDetail payementDetail)
        {
            _context.PayementDetails.Add(payementDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayementDetail", new { id = payementDetail.PayementDetailId }, payementDetail);
        }

        // DELETE: api/PayementDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayementDetail(int id)
        {
            var payementDetail = await _context.PayementDetails.FindAsync(id);
            if (payementDetail == null)
            {
                return NotFound();
            }

            _context.PayementDetails.Remove(payementDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayementDetailExists(int id)
        {
            return _context.PayementDetails.Any(e => e.PayementDetailId == id);
        }
    }
}
