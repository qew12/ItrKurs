using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItrKurs.Models
{
    public enum SortState
    {
        NameAsc,
        NameDesc,
        DescrAsc,
        DescrDesc,
        DateCreateAsc,
        DateCreateDesc
    }
    public class SortViewModel
    {

        public SortState NameSort { get; private set; } 
        public SortState DescrSort { get; private set; }    
        public SortState DateCreateSort { get; private set; }   
        public SortState Current { get; private set; } 

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DescrSort = sortOrder == SortState.DescrAsc ? SortState.DescrDesc : SortState.DescrAsc;
            DateCreateSort = sortOrder == SortState.DateCreateAsc ? SortState.DateCreateDesc : SortState.DateCreateAsc;
            Current = sortOrder;
        }
    }
}
