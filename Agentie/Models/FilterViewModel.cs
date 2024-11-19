using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Agentie.Models
{
    public class FilterViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public List<Transportare> Transports { get; set; }
        public int? HotelId { get; set; }
        public int? TransportId { get; set; }
        public string Name { get; set; }

        public SelectList HotelsSelectList { get; set; }
        public SelectList TransportsSelectList { get; set; }

        public int? SelectedHotel { get; set; }
        public int? SelectedTransportare { get; set; }
        public string SelectedName { get; set; }
        public string SelectedSName { get; set; }

        public FilterViewModel(List<Hotel> hotels, List<Transportare> transports, int? hotelId, int? transportId, string name)
        {
            Hotels = hotels;
            Transports = transports;
            HotelId = hotelId;
            TransportId = transportId;
            Name = name;

            HotelsSelectList = new SelectList(Hotels, "HotelId", "Name", hotelId);
            TransportsSelectList = new SelectList(Transports, "TransportId", "Name", transportId);
        }

        public FilterViewModel(List<Hotel> hotels, List<Transportare> transports, int? selectedHotel, int? selectedTransportare, string name, string sName)
        {
            hotels.Insert(0, new Hotel { Name = "Toate Hotelurile", HotelId = 0, Location = "N/A" });
            transports.Insert(0, new Transportare { Name = "Toate Transportările", TransportId = 0 });

            Hotels = hotels;
            Transports = transports;
            SelectedHotel = selectedHotel;
            SelectedTransportare = selectedTransportare;
            SelectedName = name;
            SelectedSName = sName;

            HotelsSelectList = new SelectList(Hotels, "HotelId", "Name", selectedHotel);
            TransportsSelectList = new SelectList(Transports, "TransportId", "Name", selectedTransportare);
        }
    }
}
