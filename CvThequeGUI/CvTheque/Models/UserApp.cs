using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvTheque.Models
{
    public class UserApp
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public string Mail { get; set; }
        public string PersonalMail { get; set; }
        public int Phone { get; set; }
        public int PersonalPhone { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Box { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public bool Licence { get; set; }
        public bool PublicTransport { get; set; }
        public int NationalityId { get; set; }
        public int SocietyId { get; set; }
        public bool IsDelete { get; set; }
        public string Password { get; set; }
    }
}