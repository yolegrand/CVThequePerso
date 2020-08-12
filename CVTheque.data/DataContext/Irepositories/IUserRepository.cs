using CVTheque.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVTheque.sata.Irepositories
{
    public interface IUserRepository
    {
        Task<User> Register(User user, string password);
        void CreatedPasswordHash(string password);
        bool VerifyPasswordHash(string password, byte[] Password, byte[] PasswordSalt);
        Task<User> Login(string username, string password);
    }
}
