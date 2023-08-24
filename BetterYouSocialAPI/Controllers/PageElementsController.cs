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
    public class PageElementsController : ControllerBase
    {
        private readonly BookContext _context;

        public PageElementsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/PageElements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageElement>>> GetPageElements()
        {
            return await _context.PageElements.ToListAsync();
        }

        // GET: api/PageElements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageElement>> GetPageElement(int id)
        {
            var pageElement = await _context.PageElements.FirstOrDefaultAsync(p => p.PageElementId == id);

            if (pageElement == null)
            {
                return NotFound();
            }

            return pageElement;
        }

        // PUT: api/PageElements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPageElement(int id, PageElement pageElement)
        {
            if (id != pageElement.PageElementId)
            {
                return BadRequest();
            }

            _context.Entry(pageElement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageElementExists(id))
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

        // POST: api/PageElements
        [HttpPost]
        public async Task<ActionResult<PageElement>> PostPageElement(PageElement pageElement)
        {
            _context.PageElements.Add(pageElement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPageElement", new { id = pageElement.PageElementId }, pageElement);
        }

        // DELETE: api/PageElements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageElement>> DeletePageElement(int id)
        {
            var pageElement = await _context.PageElements.FindAsync(id);
            if (pageElement == null)
            {
                return NotFound();
            }

            _context.PageElements.Remove(pageElement);
            await _context.SaveChangesAsync();

            return pageElement;
        }

        private bool PageElementExists(int id)
        {
            return _context.PageElements.Any(e => e.PageElementId == id);
        }
    }
}
