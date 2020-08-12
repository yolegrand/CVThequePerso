using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVTheque.core.Models;
using CVTheque.data.DataContext;
using CVTheque.sata.Irepositories;
using System.Globalization;
using CVTheque.core.ViewModels;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CVTheque.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;
        private readonly IUserRepository _userRepo;
        private static readonly TextInfo tinfo = CultureInfo.CurrentCulture.TextInfo;
        private readonly IConfiguration _config;

        public UsersController(Context context, IUserRepository userRepo, IConfiguration config)
        {
            _context = context;
            _userRepo = userRepo;
            _config = config;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/GetUserByName/name
        [HttpGet("GetUserByName/{name}")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            var user = await _context.Users.FindAsync(name);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
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

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // GET: api/Login
        [HttpPost("Login")]
        public async Task<ActionResult> Login(ViewLogin user)
        {
            User userFromRepo = await _userRepo.Login(user.Username, user.Password);
            if(userFromRepo == null)
            {
                return Unauthorized("Pas autorisé à se connecter");
            }
            var Claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials =creds
            };
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescriptor);
            try
            {
                ViewReturnUser login = new ViewReturnUser()
                {
                    Token = TokenHandler.WriteToken(token),
                    Username = userFromRepo.Username,
                    Role = userFromRepo.UserRoles.Select(r => r.role.Name).ToList()
                };
                return Ok(login);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(ViewUser user)
        {
            user.Username = user.Username.ToLower();
            if(await UserNameExists(user.Username))
            {
                return BadRequest($"l'utilisateur << {tinfo.ToTitleCase(user.Username)} >> existe déjà");
            }
            User userToCreate = new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Mail = user.Mail,
                Username = user.Username
            };
            await _userRepo.Register(userToCreate, user.Password);
            return Ok();
        }

        [HttpPost("available")]
        public async Task<IActionResult> Available(ViewUser user)
        {
            var swAvailable = await UserNameExists(user.Username);
            return Ok(!swAvailable);
        }

        private async Task<bool> UserNameExists(string username)
        {
            if ( await _context.Users.AnyAsync(e => e.Username == username))
                return true;
            return false;
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
