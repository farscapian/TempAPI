using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempApi.Models;

namespace TempApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private readonly TempContext _context;

        public TempController(TempContext context)
        {
            _context = context;

            if (_context.TempItems.Count() == 0)
            {
                // Create a new Tempitem if the collection is empty.
                // this means you can't delete all TempItems.
                _context.TempItems.Add(new TempItem { HeaterAction = "off", SensorName = "AUTO_GENERATED_RECORD", Temperature = 25.0M, Timestamp = DateTime.Now });
                _context.SaveChanges();
            }
        }

        // GET: api/Temp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TempItem>>> GetTempItems()
        {
            return await _context.TempItems.ToListAsync();
        }

        // GET: api/Temp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TempItem>> GetTempItem(long id)
        {
            var tempItem = await _context.TempItems.FindAsync(id);

            if (tempItem == null)
            {
                return NotFound();
            }

            return tempItem;
        }

        // POST: api/temp
        [HttpPost]
        public async Task<ActionResult<TempItem>> PostTempItem(TempItem item)
        {
            _context.TempItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTempItem), new { id = item.Id }, item);
        }

        // PUT: api/Temp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTempItem(long id, TempItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/temp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempItem(long id)
        {
            var tempItem = await _context.TempItems.FindAsync(id);

            if (tempItem == null)
            {
                return NotFound();
            }

            _context.TempItems.Remove(tempItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
