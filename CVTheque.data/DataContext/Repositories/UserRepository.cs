using CVTheque.core.Models;
using CVTheque.data.DataContext;
using CVTheque.sata.Irepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTheque.data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        byte[] PasswordHash, PasswordSalt;

        public UserRepository(Context context)
        {
            _context = context;
        }
        

        public async Task<User> Login(string username, string password)
        {
            try
            {
                User user = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.role).FirstOrDefaultAsync(x => x.Username == username);

                if (user == null)
                {
                    return null;
                }
                if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
                    return null;
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async  Task<User> Register(User user, string password)
        {
            try
            {
                
                CreatedPasswordHash(password);
                user.Password = PasswordHash;
                user.PasswordSalt = PasswordSalt;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return user;
        }

        public void CreatedPasswordHash(string password)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    PasswordSalt = hmac.Key;
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool VerifyPasswordHash(string password, byte[] Password, byte[] PasswordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
                {
                    var conputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < conputeHash.Length; i++)
                    {
                        if (conputeHash[i] != Password[i])
                            return false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
    }
}
