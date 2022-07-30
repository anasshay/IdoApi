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
  public class UsersController : ControllerBase
  {
    private readonly IdoContext _context;

    public UsersController(IdoContext context)
    {
      _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
    {
      if (_context.Users == null)
      {
        return NotFound();
      }
      return await _context.Users.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> GetUser(int id)
    {
      if (_context.Users == null)
      {
        return NotFound();
      }
      var user = await _context.Users.FindAsync(id);

      // var userX = _context.Users.Include(s => s.Cards).Include(s => s.Importances)

      // var userX = await (from u in _context.Users
      //                    where u.Id == id
      //                    select new UserModel
      //                    {
      //                      Id = u.Id,
      //                      Email = u.Email,
      //                      Password = u.Password,
      //                      Photo = u.Photo,
      //                      Cards = (from card in _context.Cards
      //                               where card.UserId == id
      //                               select new CardModel
      //                               {
      //                                 Id = card.Id,
      //                                 Title = card.Title,
      //                                 Importance = card.Importance,
      //                                 UserId = card.UserId,
      //                               }).ToList()
      //                    }).FirstOrDefaultAsync();

      var userX = await _context.Users.Where(u => u.Id == id).Include(c => c.Cards).ToListAsync();


      //   card?.Select(s => new CardModel
      //   {
      //     Id = s.Id,
      //     Importance = s.Importance,
      //     ImportanceId = s.Importance.Id,
      //     prefix = s.prefix,
      //     StateId = s.StateId,
      //   }).ToList(),
      // }).FirstOrDefaultAsync();



      if (user == null)
      {
        return NotFound();
      }

      // get all cards of this user
      var cards = await _context.Cards.Where(c => c.UserId == id).ToListAsync();

      // get the importance of each card
      foreach (var card in cards)
      {
        var importance = await _context.Importances.FindAsync(card.ImportanceId);
        card.Importance = importance;
      }

      // get the state for each card
      foreach (var card in cards)
      {
        var state = await _context.States.FindAsync(card.StateId);
        card.prefix = state;
      }

      user.Cards = cards;

      return Ok(userX);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, [FromForm] UserModel user)
    {
      if (id != user.Id)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(new { message = "Card has been edited successfully", user });
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<UserModel>> PostUser([FromForm] UserModel user)
    {
      if (_context.Users == null)
      {
        return Problem("Entity set 'IdoContext.Users'  is null.");
      }
      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      if (_context.Users == null)
      {
        return NotFound();
      }
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

      //return json of user deleted with message
      return Ok(new { message = "User deleted successfully" });
    }

    private bool UserExists(int id)
    {
      return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
