using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantListsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public RestaurantListsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantList>>> GetRestaurantList()
        {
            return await _context.RestaurantList.ToListAsync();
        }

        // GET: api/RestaurantLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantList>> GetRestaurantList(int id)
        {
            var restaurantList = await _context.RestaurantList.FindAsync(id);

            if (restaurantList == null)
            {
                return NotFound();
            }

            return restaurantList;
        }

        // PUT: api/RestaurantLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantList(int id, RestaurantList restaurantList)
        {
            if (id != restaurantList.ID)
            {
                return BadRequest();
            }

            _context.Entry(restaurantList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantListExists(id))
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

        // POST: api/RestaurantLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantList>> PostRestaurantList(RestaurantList restaurantList)
        {
            _context.RestaurantList.Add(restaurantList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantList", new { id = restaurantList.ID }, restaurantList);
        }

        // DELETE: api/RestaurantLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantList(int id)
        {
            var restaurantList = await _context.RestaurantList.FindAsync(id);
            if (restaurantList == null)
            {
                return NotFound();
            }

            _context.RestaurantList.Remove(restaurantList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantListExists(int id)
        {
            return _context.RestaurantList.Any(e => e.ID == id);
        }
    }
}
