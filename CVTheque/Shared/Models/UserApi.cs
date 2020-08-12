using System;
using System.Collections.Generic;
using System.Text;

namespace CVTheque.Shared.Models
{
    public class UserApi : BasicInformation
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDelete { get; set; }
    }
}
