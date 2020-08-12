using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVTheque.core.Models;
using CVTheque.data.DataContext;
using CVThequeApiCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CVThequeApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LevelsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LevelsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelApi>>> GetLevels()
        {
            IEnumerable<Level> level = await _context.Levels.ToListAsync();
            IEnumerable<LevelApi> levelApi = _mapper.Map<IEnumerable<Level>, IEnumerable<LevelApi>>(level);
            return Ok(levelApi);
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(int id)
        {
            Level level = await _context.Levels.FindAsync(id);
            LevelApi levelApi = _mapper.Map<Level, LevelApi>(level);

            if (level == null)
            {
                return NotFound();
            }

            return Ok(levelApi);
        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(int id, LevelApi levelApi)
        {
            Level level = _mapper.Map<LevelApi, Level>(levelApi);

            if (id != level.Id)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                _context.Levels.Update(level);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(LevelApi levelApi)
        {
            Level level = _mapper.Map<LevelApi, Level>(levelApi);
            _context.Levels.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = levelApi.Id }, levelApi);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LevelApi>> DeleteLevel(int id)
        {
            Level level = await _context.Levels.FindAsync(id);
            LevelApi levelApi = _mapper.Map<Level, LevelApi>(level);
            if (level == null)
            {
                return NotFound();
            }
            try
            {
                _context.Levels.Remove(level);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return levelApi;
        }

        private bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }
    }
}
