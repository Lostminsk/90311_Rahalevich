using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;

namespace _90311_Rahalevich.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsulinsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InsulinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Insulins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insulin>>> GetInsulins(int?
group)
        {
            return await _context
            .Insulins
            .Where(d => !group.HasValue
            || d.InsulinGroupId.Equals(group.Value))
            ?.ToListAsync();
        }
        
        
        
        // GET: api/Insulins/5
                [HttpGet("{id}")]
        public async Task<ActionResult<Insulin>> GetInsulin(int id)
        {
            var insulin = await _context.Insulins.FindAsync(id);

            if (insulin == null)
            {
                return NotFound();
            }

            return insulin;
        }

        // PUT: api/Insulins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsulin(int id, Insulin insulin)
        {
            if (id != insulin.InsulinId)
            {
                return BadRequest();
            }

            _context.Entry(insulin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsulinExists(id))
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

        // POST: api/Insulins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Insulin>> PostInsulin(Insulin insulin)
        {
            _context.Insulins.Add(insulin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsulin", new { id = insulin.InsulinId }, insulin);
        }

        // DELETE: api/Insulins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Insulin>> DeleteInsulin(int id)
        {
            var insulin = await _context.Insulins.FindAsync(id);
            if (insulin == null)
            {
                return NotFound();
            }

            _context.Insulins.Remove(insulin);
            await _context.SaveChangesAsync();

            return insulin;
        }

        private bool InsulinExists(int id)
        {
            return _context.Insulins.Any(e => e.InsulinId == id);
        }
    }
}
