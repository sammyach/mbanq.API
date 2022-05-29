using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mbanq.API.Data;

namespace mbanq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly MBANQContext _context;

        public OrganizationsController(MBANQContext context)
        {
            _context = context;
        }

        // GET: api/Organizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MbqOrganization>>> GetMbqOrganizations()
        {
          if (_context.MbqOrganizations == null)
          {
              return NotFound();
          }
            return await _context.MbqOrganizations.ToListAsync();
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MbqOrganization>> GetMbqOrganization(int id)
        {
          if (_context.MbqOrganizations == null)
          {
              return NotFound();
          }
            var mbqOrganization = await _context.MbqOrganizations.FindAsync(id);

            if (mbqOrganization == null)
            {
                return NotFound();
            }

            return mbqOrganization;
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMbqOrganization(int id, MbqOrganization mbqOrganization)
        {
            if (id != mbqOrganization.Id)
            {
                return BadRequest();
            }

            _context.Entry(mbqOrganization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MbqOrganizationExists(id))
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

        // POST: api/Organizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MbqOrganization>> PostMbqOrganization(MbqOrganization mbqOrganization)
        {
          if (_context.MbqOrganizations == null)
          {
              return Problem("Entity set 'MBANQContext.MbqOrganizations'  is null.");
          }
            _context.MbqOrganizations.Add(mbqOrganization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMbqOrganization", new { id = mbqOrganization.Id }, mbqOrganization);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMbqOrganization(int id)
        {
            if (_context.MbqOrganizations == null)
            {
                return NotFound();
            }
            var mbqOrganization = await _context.MbqOrganizations.FindAsync(id);
            if (mbqOrganization == null)
            {
                return NotFound();
            }

            _context.MbqOrganizations.Remove(mbqOrganization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MbqOrganizationExists(int id)
        {
            return (_context.MbqOrganizations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
