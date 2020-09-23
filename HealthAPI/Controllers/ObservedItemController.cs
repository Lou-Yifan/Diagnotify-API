using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;

namespace HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservedItemController : ControllerBase
    {
        private readonly HealthContext _context;

        public ObservedItemController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/ObservedItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservedItem>>> GetObservedItems()
        {
            return await _context.ObservedItems.ToListAsync();
        }

        // GET: api/ObservedItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObservedItem>> GetObservedItem(int id)
        {
            var observedItem = await _context.ObservedItems.FindAsync(id);

            if (observedItem == null)
            {
                return NotFound();
            }

            return observedItem;
        }

        // PUT: api/ObservedItem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObservedItem(int id, ObservedItem observedItem)
        {
            if (id != observedItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(observedItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservedItemExists(id))
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

        // POST: api/ObservedItem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ObservedItem>> PostObservedItem(ObservedItem observedItem)
        {
            _context.ObservedItems.Add(observedItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObservedItem", new { id = observedItem.ID }, observedItem);
        }

        // DELETE: api/ObservedItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ObservedItem>> DeleteObservedItem(int id)
        {
            var observedItem = await _context.ObservedItems.FindAsync(id);
            if (observedItem == null)
            {
                return NotFound();
            }

            _context.ObservedItems.Remove(observedItem);
            await _context.SaveChangesAsync();

            return observedItem;
        }

        private bool ObservedItemExists(int id)
        {
            return _context.ObservedItems.Any(e => e.ID == id);
        }
    }
}
