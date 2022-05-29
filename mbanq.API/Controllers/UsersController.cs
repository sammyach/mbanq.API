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
    public class UsersController : ControllerBase
    {
        private readonly MBANQContext _context;

        public UsersController(MBANQContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MbqAppUser>>> GetMbqAppUsers()
        {
          if (_context.MbqAppUsers == null)
          {
              return NotFound();
          }
            return await _context.MbqAppUsers.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MbqAppUser>> GetMbqAppUser(int id)
        {
          if (_context.MbqAppUsers == null)
          {
              return NotFound();
          }
            var mbqAppUser = await _context.MbqAppUsers.FindAsync(id);

            if (mbqAppUser == null)
            {
                return NotFound();
            }

            return mbqAppUser;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMbqAppUser(int id, MbqAppUser mbqAppUser)
        {
            if (id != mbqAppUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(mbqAppUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MbqAppUserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MbqAppUser>> PostMbqAppUser(MbqAppUser mbqAppUser)
        {
          if (_context.MbqAppUsers == null)
          {
              return Problem("Entity set 'MBANQContext.MbqAppUsers'  is null.");
          }
            _context.MbqAppUsers.Add(mbqAppUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMbqAppUser", new { id = mbqAppUser.Id }, mbqAppUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMbqAppUser(int id)
        {
            if (_context.MbqAppUsers == null)
            {
                return NotFound();
            }
            var mbqAppUser = await _context.MbqAppUsers.FindAsync(id);
            if (mbqAppUser == null)
            {
                return NotFound();
            }

            _context.MbqAppUsers.Remove(mbqAppUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MbqAppUserExists(int id)
        {
            return (_context.MbqAppUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
