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
  public class StatesController : ControllerBase
  {
    private readonly IdoContext _context;

    public StatesController(IdoContext context)
    {
      _context = context;
    }

    // GET: api/States
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StateModel>>> GetState()
    {
      if (_context.States == null)
      {
        return NotFound();
      }
      return await _context.States.ToListAsync();
    }

    // GET: api/States/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StateModel>> GetState(int id)
    {
      if (_context.States == null)
      {
        return NotFound();
      }
      var state = await _context.States.FindAsync(id);

      if (state == null)
      {
        return NotFound();
      }

      return state;
    }

    // PUT: api/States/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutState(int id, [FromForm] StateModel state)
    {
      if (id != state.Id)
      {
        return BadRequest();
      }

      _context.Entry(state).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(new { message = "Card has been edited successfully", state });
    }

    // POST: api/States
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<StateModel>> PostState([FromForm] StateModel state)
    {
      if (_context.States == null)
      {
        return Problem("Entity set 'IdoContext.State'  is null.");
      }
      _context.States.Add(state);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetState", new { id = state.Id }, state);
    }

    // DELETE: api/States/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteState(int id)
    {
      if (_context.States == null)
      {
        return NotFound();
      }
      var state = await _context.States.FindAsync(id);
      if (state == null)
      {
        return NotFound();
      }

      _context.States.Remove(state);
      await _context.SaveChangesAsync();

      return Ok(new { message = "State deleted successfully" });

    }

    private bool StateExists(int id)
    {
      return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
