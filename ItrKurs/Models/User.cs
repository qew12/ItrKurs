using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ItrKurs.ViewModels;

namespace ItrKurs.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            Collections = new List<Collection>();
        }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset Lastlogin { get; set; }
        public string Status { get; set; }
        public bool IsSelected { get; set; }
        public List<Collection> Collections { get; set; }

        //public string Role { get; set; }

    }

    

}
