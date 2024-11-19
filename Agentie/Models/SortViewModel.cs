using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // valoarea pentru sortare după nume
        public SortState AgeSort { get; private set; }    // valoarea pentru sortare după vârstă
        public SortState CompanySort { get; private set; }   // valoarea pentru sortare după companie
        public SortState Current { get; private set; }     // valoarea sortării curente

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            CompanySort = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            Current = sortOrder;
        }
    }
}
