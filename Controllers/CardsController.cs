using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdoApi.Models;

namespace IdoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IdoContext _context;

        public CardsController(IdoContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardModel>>> GetCardModel()
        {
          if (_context.CardModel == null)
          {
              return NotFound();
          }
            return await _context.CardModel.ToListAsync();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardModel>> GetCardModel(int id)
        {
          if (_context.CardModel == null)
          {
              return NotFound();
          }
            var cardModel = await _context.CardModel.FindAsync(id);

            if (cardModel == null)
            {
                return NotFound();
            }

            return cardModel;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardModel(int id, CardModel cardModel)
        {
            if (id != cardModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardModelExists(id))
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

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardModel>> PostCardModel(CardModel cardModel)
        {
          if (_context.CardModel == null)
          {
              return Problem("Entity set 'IdoContext.CardModel'  is null.");
          }
            _context.CardModel.Add(cardModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardModel", new { id = cardModel.Id }, cardModel);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardModel(int id)
        {
            if (_context.CardModel == null)
            {
                return NotFound();
            }
            var cardModel = await _context.CardModel.FindAsync(id);
            if (cardModel == null)
            {
                return NotFound();
            }

            _context.CardModel.Remove(cardModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardModelExists(int id)
        {
            return (_context.CardModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
