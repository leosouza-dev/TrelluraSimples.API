using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aura.Trellura.Domain.Entities;
using TrelluraSimples.API.Data;

namespace TrelluraSimples.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly DataContext _context;

        public BoardsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Boards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Board>>> GetBoards()
        {
            return await _context.Boards.ToListAsync();
        }

        // GET: api/Boards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetBoard(Guid id)
        {
            var board = await _context.Boards.FindAsync(id);

            if (board == null)
            {
                return NotFound();
            }

            return board;
        }

        // PUT: api/Boards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard(Guid id, Board board)
        {
            if (id != board.Id)
            {
                return BadRequest();
            }

            _context.Entry(board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // POST: api/Boards
        [HttpPost]
        public async Task<ActionResult<Board>> PostBoard(Board board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoard", new { id = board.Id }, board);
        }

        // DELETE: api/Boards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Board>> DeleteBoard(Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return board;
        }

        private bool BoardExists(Guid id)
        {
            return _context.Boards.Any(e => e.Id == id);
        }
    }
}
