using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace HealthAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HealthPolicy")]
    public class ObservedItemController : ControllerBase
    {
        private readonly HealthContext _context;

        public ObservedItemController(HealthContext context)
        {
            _context = context;
        }

        // Get all the observedItems
        // GET: api/ObservedItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservedItem>>> GetObservedItems()
        {
            return await _context.ObservedItems
                .Include(bp => bp.bloodPressures)
                .Include(bh => bh.bodyHeats)
                .Include(rr => rr.respiratoryRates)
                .Include(sr => sr.sinusRhythms)
                .ToListAsync();
        }


        private bool ObservedItemExists(string id)
        {
            return _context.ObservedItems.Any(e => e.ObservedItemId == id);
        }
    }
}
