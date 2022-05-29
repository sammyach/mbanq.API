using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mbanq.API.Data;
using mbanq.API.Dtos;
using mbanq.API.Helpers;

namespace mbanq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly MBANQContext _context;

        public BranchesController(MBANQContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MbqBranch>>> GetMbqBranches()
        {
          if (_context.MbqBranches == null)
          {
              return NotFound();
          }
            return await _context.MbqBranches.ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MbqBranch>> GetMbqBranch(int id)
        {
          if (_context.MbqBranches == null)
          {
              return NotFound();
          }
            var mbqBranch = await _context.MbqBranches.FindAsync(id);

            if (mbqBranch == null)
            {
                return NotFound();
            }

            return mbqBranch;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMbqBranch(int id, MbqBranch mbqBranch)
        {
            if (id != mbqBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(mbqBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MbqBranchExists(id))
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

        // POST: api/Branches/new
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<MbqBranch>> PostMbqBranch(NewBranchDto data)
        {
            var user = HttpContext.Items["User"] as MbqAppUser;
            if (user == null) return BadRequest();

            if (_context.MbqBranches == null)
            {
                return Problem("Entity set 'MBANQContext.MbqBranches'  is null.");
            }

            var branch = new MbqBranch { OrganizationId = data.OrganizationId, IsHead = data.IsHead, ResidentialAddress = data.ResidentialAddress, DigitalAddress = data.DigitalAddress, City = data.City, RegionId = data.RegionId, StateId = data.StateId, Phone = data.Phone, Email = data.Email, Alias = data.Alias };
            branch.DateCreated = DateTime.UtcNow;
            branch.Active = false;
            branch.CreatedBy = user.Email;
            _context.MbqBranches.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMbqBranch", new { id = branch.Id }, branch);
        }

        [Authorize]
        [HttpPatch]
        [Route("activate")]
        public async Task<IActionResult> ActivateBranch(ActivateBranchDto data)
        {
            var user = HttpContext.Items["User"] as MbqAppUser;
            if (user == null) return BadRequest();
            var branch = await _context.MbqBranches.Where(x=>x.Id == data.BranchId && x.OrganizationId == data.OrganizationId).FirstOrDefaultAsync();
            if (branch == null) return NotFound("Branch does not exist");
            branch.Active = true;
            branch.LastModifiedDate = DateTime.UtcNow;
            branch.ModifiedBy = user.Email;
            _context.Update(branch);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMbqBranch(int id)
        {
            if (_context.MbqBranches == null)
            {
                return NotFound();
            }
            var mbqBranch = await _context.MbqBranches.FindAsync(id);
            if (mbqBranch == null)
            {
                return NotFound();
            }

            _context.MbqBranches.Remove(mbqBranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MbqBranchExists(int id)
        {
            return (_context.MbqBranches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
