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
    public class MetricsController : ControllerBase
    {
        private readonly BookContext _context;

        public MetricsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Metrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metric>>> GetMetrics()
        {
            return await _context.Metrics.ToListAsync();
        }

        // GET: api/Metrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metric>> GetMetric(int id)
        {
            var metric = await _context.Metrics.FirstOrDefaultAsync(m => m.MetricId == id);

            if (metric == null)
            {
                return NotFound();
            }

            return metric;
        }

        // PUT: api/Metrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetric(int id, Metric metric)
        {
            if (id != metric.MetricId)
            {
                return BadRequest();
            }

            _context.Entry(metric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricExists(id))
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

        // POST: api/Metrics
        [HttpPost]
        public async Task<ActionResult<Metric>> PostMetric(Metric metric)
        {
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetric", new { id = metric.MetricId }, metric);
        }

        // DELETE: api/Metrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Metric>> DeleteMetric(int id)
        {
            var metric = await _context.Metrics.FindAsync(id);
            if (metric == null)
            {
                return NotFound();
            }

            _context.Metrics.Remove(metric);
            await _context.SaveChangesAsync();

            return metric;
        }

        private bool MetricExists(int id)
        {
            return _context.Metrics.Any(e => e.MetricId == id);
        }
    }
}
