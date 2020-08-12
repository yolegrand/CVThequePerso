using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVTheque.api.Models;
using CVTheque.core.Models;
using CVTheque.data.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVTheque.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageLevelsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LanguageLevelsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageLevelApi>>> GetLevels()
        {
            IEnumerable<LanguageLevel> level = await _context.LanguageLevels.ToListAsync();
            IEnumerable<LanguageLevelApi> levelApi = _mapper.Map<IEnumerable<LanguageLevel>, IEnumerable<LanguageLevelApi>>(level);
            return Ok(levelApi);
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageLevel>> GetLevel(int id)
        {
            LanguageLevel level = await _context.LanguageLevels.FindAsync(id);
            LanguageLevelApi levelApi = _mapper.Map<LanguageLevel, LanguageLevelApi>(level);

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
        public async Task<IActionResult> PutLevel(int id, LanguageLevelApi levelApi)
        {
            LanguageLevel level = _mapper.Map<LanguageLevelApi, LanguageLevel>(levelApi);

            if (id != level.Id)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                _context.LanguageLevels.Update(level);
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
        public async Task<ActionResult<LanguageLevel>> PostLevel(LanguageLevelApi levelApi)
        {
            LanguageLevel level = _mapper.Map<LanguageLevelApi, LanguageLevel>(levelApi);
            _context.LanguageLevels.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = levelApi.Id }, levelApi);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LanguageLevelApi>> DeleteLevel(int id)
        {
            LanguageLevel level = await _context.LanguageLevels.FindAsync(id);
            LanguageLevelApi levelApi = _mapper.Map<LanguageLevel, LanguageLevelApi>(level);
            if (level == null)
            {
                return NotFound();
            }
            try
            {
                _context.LanguageLevels.Remove(level);
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

