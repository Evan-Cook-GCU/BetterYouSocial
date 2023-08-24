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
    public class MetricTypesController : ControllerBase
    {
        private readonly BookContext _context;

        public MetricTypesController(BookContext context)
        {
            _context = context;
        }

        // GET: api/MetricTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetricType>>> GetMetricTypes()
        {
            return await _context.MetricTypes.ToListAsync();
        }

        // GET: api/MetricTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetricType>> GetMetricType(int id)
        {
            var metricType = await _context.MetricTypes.FirstOrDefaultAsync(m => m.MetricTypeId == id);

            if (metricType == null)
            {
                return NotFound();
            }

            return metricType;
        }

        // PUT: api/MetricTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetricType(int id, MetricType metricType)
        {
            if (id != metricType.MetricTypeId)
            {
                return BadRequest();
            }

            _context.Entry(metricType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricTypeExists(id))
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

        // POST: api/MetricTypes
        [HttpPost]
        public async Task<ActionResult<MetricType>> PostMetricType(MetricType metricType)
        {
            _context.MetricTypes.Add(metricType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetricType", new { id = metricType.MetricTypeId }, metricType);
        }

        // DELETE: api/MetricTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MetricType>> DeleteMetricType(int id)
        {
            var metricType = await _context.MetricTypes.FindAsync(id);
            if (metricType == null)
            {
                return NotFound();
            }

            _context.MetricTypes.Remove(metricType);
            await _context.SaveChangesAsync();

            return metricType;
        }

        private bool MetricTypeExists(int id)
        {
            return _context.MetricTypes.Any(e => e.MetricTypeId == id);
        }
    }
}
