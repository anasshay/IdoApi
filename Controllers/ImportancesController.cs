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
  public class ImportancesController : ControllerBase
  {
    private readonly IdoContext _context;

    public ImportancesController(IdoContext context)
    {
      _context = context;
    }

    // GET: api/Importances
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImportanceModel>>> GetImportanceModel()
    {
      if (_context.Importances == null)
      {
        return NotFound();
      }
      return await _context.Importances.ToListAsync();
    }

    // GET: api/Importances/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ImportanceModel>> GetImportanceModel(int id)
    {
      if (_context.Importances == null)
      {
        return NotFound();
      }
      var importanceModel = await _context.Importances.FindAsync(id);

      if (importanceModel == null)
      {
        return NotFound();
      }

      return importanceModel;
    }

    // PUT: api/Importances/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutImportanceModel(int id, [FromForm] ImportanceModel importanceModel)
    {
      if (id != importanceModel.Id)
      {
        return BadRequest();
      }

      _context.Entry(importanceModel).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ImportanceModelExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(new { message = "Importance has been edited successfully", importanceModel });
    }

    // POST: api/Importances
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ImportanceModel>> PostImportanceModel([FromForm] ImportanceModel importanceModel)
    {
      if (_context.Importances == null)
      {
        return Problem("Entity set 'IdoContext.ImportanceModel'  is null.");
      }
      _context.Importances.Add(importanceModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetImportanceModel", new { id = importanceModel.Id }, importanceModel);
    }

    // DELETE: api/Importances/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImportanceModel(int id)
    {
      if (_context.Importances == null)
      {
        return NotFound();
      }
      var importanceModel = await _context.Importances.FindAsync(id);
      if (importanceModel == null)
      {
        return NotFound();
      }

      _context.Importances.Remove(importanceModel);
      await _context.SaveChangesAsync();

      return Ok(new { message = "Importance deleted successfully" });

    }

    private bool ImportanceModelExists(int id)
    {
      return (_context.Importances?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
