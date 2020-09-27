using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItrKurs.Models
{
    public class PersonalCollectionViewModel
    {
        public IEnumerable<Collection> Collections { get; set; }
        //public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
