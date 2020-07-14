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
    public class BoardListsController : ControllerBase
    {
        private readonly DataContext _context;

        public BoardListsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BoardLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardList>>> GetBoardLists()
        {
            return await _context.BoardLists.ToListAsync();
        }

        // GET: api/BoardLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardList>> GetBoardList(Guid id)
        {
            var boardList = await _context.BoardLists.FindAsync(id);

            if (boardList == null)
            {
                return NotFound();
            }

            return boardList;
        }

        // PUT: api/BoardLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoardList(Guid id, BoardList boardList)
        {
            if (id != boardList.Id)
            {
                return BadRequest();
            }

            _context.Entry(boardList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardListExists(id))
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

        // POST: api/BoardLists
        [HttpPost]
        public async Task<ActionResult<BoardList>> PostBoardList(BoardList boardList)
        {
            _context.BoardLists.Add(boardList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoardList", new { id = boardList.Id }, boardList);
        }

        // DELETE: api/BoardLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoardList>> DeleteBoardList(Guid id)
        {
            var boardList = await _context.BoardLists.FindAsync(id);
            if (boardList == null)
            {
                return NotFound();
            }

            _context.BoardLists.Remove(boardList);
            await _context.SaveChangesAsync();

            return boardList;
        }

        private bool BoardListExists(Guid id)
        {
            return _context.BoardLists.Any(e => e.Id == id);
        }
    }
}
