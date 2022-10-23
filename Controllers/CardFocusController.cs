using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using react_axois_API_Fetch.Models;

namespace react_axois_API_Fetch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardFocusController : ControllerBase
    {
        private readonly React_Fetch_APIContext _context;

        public CardFocusController(React_Fetch_APIContext context)
        {
            _context = context;
        }

        // GET: api/CardFocus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardFocus>>> GetCardFoci()
        {
            return await _context.CardFoci.ToListAsync();
        }

        // GET: api/CardFocus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardFocus>> GetCardFocus(int id)
        {
            var cardFocus = await _context.CardFoci.FindAsync(id);

            if (cardFocus == null)
            {
                return NotFound();
            }

            return cardFocus;
        }

        // PUT: api/CardFocus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardFocus(int id, CardFocus cardFocus)
        {
            if (id != cardFocus.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardFocus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardFocusExists(id))
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

        // POST: api/CardFocus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardFocus>> PostCardFocus(CardFocus cardFocus)
        {
            _context.CardFoci.Add(cardFocus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardFocus", new { id = cardFocus.Id }, cardFocus);
        }

        // DELETE: api/CardFocus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardFocus(int id)
        {
            var cardFocus = await _context.CardFoci.FindAsync(id);
            if (cardFocus == null)
            {
                return NotFound();
            }

            _context.CardFoci.Remove(cardFocus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardFocusExists(int id)
        {
            return _context.CardFoci.Any(e => e.Id == id);
        }
    }
}
