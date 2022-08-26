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
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceItemsController : ControllerBase
    {
        private readonly ServiceContext _context;

        public ServiceItemsController(ServiceContext context)
        {
            _context = context;
        }

        // GET: api/ServiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceItems>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/ServiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceItems>> GetServiceItems(Guid id)
        {
            var serviceItems = await _context.TodoItems.FindAsync(id);

            if (serviceItems == null)
            {
                return NotFound();
            }

            return serviceItems;
        }

        // PUT: api/ServiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceItems(Guid id, ServiceItems serviceItems)
        {
            if (id != serviceItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceItemsExists(id))
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
        public async Task<ActionResult<ServiceItems>> PostServiceItems(ServiceItems serviceItems)
        {
            _context.TodoItems.Add(serviceItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceItems", new { id = serviceItems.Id }, serviceItems);
        }

        // DELETE: api/ServiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceItems(Guid id)
        {
            var serviceItems = await _context.TodoItems.FindAsync(id);
            if (serviceItems == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(serviceItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceItemsExists(Guid id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
