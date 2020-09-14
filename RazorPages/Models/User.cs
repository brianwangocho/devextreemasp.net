using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class User
    {

        public int id { get; set; }

        public string name { get; set; }

        public string phone { get; set; }
        public string email { get; set; }

        public string gender { get; set; }

        public DateTime? dob { get; set; }

        public string password { get; set; }

        public string fcmToken { get; set; }
        public DateTime? tokenExpiryDate { get; set; }
        public DateTime? tokenCreationOn { get; set; }

        public static implicit operator List<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}
