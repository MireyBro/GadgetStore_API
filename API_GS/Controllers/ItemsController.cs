using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_GS.Domain.EF;
using API_GS.Models;

namespace API_GS.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly EFGsDBContext _context;

        public ItemsController(EFGsDBContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetServiceItems()
        {
            return await _context.ShopItems.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItem>> GetItems(int id)
        {
            var items = await _context.ShopItems.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, ShopItem items)
        {
            if (id != items.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostItems(ShopItem items)
        {
            _context.ShopItems.Add(items);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = items.ItemId }, items);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems(int id)
        {
            var items = await _context.ShopItems.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.ShopItems.Remove(items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemsExists(int id)
        {
            return _context.ShopItems.Any(e => e.ItemId == id);
        }
    }
}
