using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_GS.Models;

namespace API_GS.Controllers
{
    [Route("api/serviceitems")]
    [ApiController]
    public class ServiceItemsController : ControllerBase
    {
        private readonly EFServiceDBContext _context;

        public ServiceItemsController(EFServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/ServiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceItem>>> GetServiceItems()
        {
            return await _context.ServiceItems.ToListAsync();
        }

        // GET: api/ServiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceItem>> GetServiceItem(int id)
        {
            var serviceItem = await _context.ServiceItems.FindAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }

            return serviceItem;
        }

        // PUT: api/ServiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceItem(int id, ServiceItem serviceItem)
        {
            if (id != serviceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceItemExists(id))
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

        // POST: api/ServiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceItem>> PostServiceItem(ServiceItem serviceItem)
        {
            _context.ServiceItems.Add(serviceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceItem), new { id = serviceItem.Id }, serviceItem);
        }

        // DELETE: api/ServiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceItem(int id)
        {
            var serviceItem = await _context.ServiceItems.FindAsync(id);
            if (serviceItem == null)
            {
                return NotFound();
            }

            _context.ServiceItems.Remove(serviceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceItemExists(int id)
        {
            return _context.ServiceItems.Any(e => e.Id == id);
        }
    }
}
