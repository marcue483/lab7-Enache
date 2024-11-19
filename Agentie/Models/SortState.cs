using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public enum SortState
    {
        NameAsc,    // după nume crescător
        NameDesc,   // după nume descrescător
        AgeAsc,     // după vârstă crescător
        AgeDesc,    // după vârstă descrescător
        CompanyAsc, // după companie crescător
        CompanyDesc // după companie descrescător
    }
}
