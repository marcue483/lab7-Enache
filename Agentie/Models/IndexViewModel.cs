using Agentie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class IndexViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Transportare> Transports { get; set; }
        public string SelectedName { get; set; }
        public string SelectedSName { get; set; }

        public IndexViewModel(PageViewModel pageViewModel, SortViewModel sortViewModel, FilterViewModel filterViewModel, List<Hotel> hotels, List<Transportare> transports, string selectedName, string selectedSName)
        {
            PageViewModel = pageViewModel ?? throw new ArgumentNullException(nameof(pageViewModel));
            SortViewModel = sortViewModel ?? throw new ArgumentNullException(nameof(sortViewModel));
            FilterViewModel = filterViewModel ?? throw new ArgumentNullException(nameof(filterViewModel));
            Hotels = hotels ?? throw new ArgumentNullException(nameof(hotels));
            Transports = transports ?? throw new ArgumentNullException(nameof(transports));
            SelectedName = selectedName;
            SelectedSName = selectedSName;
        }
    }
}