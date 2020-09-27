using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ItrKurs.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Collection> collections, string name ,string description,string discriminator, string user)
        {
            SelectedName = name;
            SelectedDiscriminator = discriminator;
            SelectedUser = user;
        }

        public string SelectedName { get; private set; }
        public string SelectedUser { get; private set; }
        public string SelectedDiscriminator { get; private set; }
        public string SelectedDescription { get; private set; }
        //public bool? SelectedBool1 { get; private set; }
        //public int? SelectedInt1 { get; private set; } 

    }
}
