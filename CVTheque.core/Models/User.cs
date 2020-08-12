using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDelete { get; set; }

        //public User()
        //{
        //    UserRoles = new List<UserRole>();
        //}
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
