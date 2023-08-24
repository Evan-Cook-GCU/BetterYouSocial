using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterYouSocialAPI;

namespace BetterYouSocialAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly BookContext _context;

        public PagesController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await _context.Pages.ToListAsync();
        }

        // GET: api/Pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await _context.Pages.FirstOrDefaultAsync(p => p.PageId == id);

            if (page == null)
            {
                return NotFound();
            }

            return page;
        }

        // PUT: api/Pages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, Page page)
        {
            if (id != page.PageId)
            {
                return BadRequest();
            }

            _context.Entry(page).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
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

        // POST: api/Pages
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage(Page page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPage", new { id = page.PageId }, page);
        }

        // DELETE: api/Pages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Page>> DeletePage(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();

            return page;
        }

        private bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}
