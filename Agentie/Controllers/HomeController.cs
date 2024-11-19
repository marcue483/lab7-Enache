using Agentie.Data;
using Agentie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Agentie.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentieContext db;

        public HomeController(AgentieContext context)
        {
            db = context;

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (!db.Hotels.Any())
            {
                db.Hotels.AddRange(new[]
                {
                    new Hotel { Name = "Hotel California", Price = 200, Stele = 5, Location = "California", ClientId = 1, PackageId = 1 },
                    new Hotel { Name = "Hotel Paris", Price = 150, Stele = 4, Location = "Paris", ClientId = 1, PackageId = 2 }
                    
                });
                db.SaveChanges();
            }

            if (!db.Transports.Any())
            {
                db.Transports.AddRange(new[]
                {
                    new Transportare { Name = "Transport Company A", Price = 100, Data = DateTime.Now, PersonNR = 1, ClientId = 1 },
                    new Transportare { Name = "Transport Company B", Price = 150, Data = DateTime.Now.AddDays(1), PersonNR = 2, ClientId = 1 }
                });
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(int? hotelId, int? transportId, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 5;

            IQueryable<Hotel> hotels = db.Hotels.Include(h => h.Transports);
            IQueryable<Transportare> transports = db.Transports;

            if (hotelId.HasValue && hotelId != 0)
                hotels = hotels.Where(h => h.HotelId == hotelId);
            if (transportId.HasValue && transportId != 0)
                transports = transports.Where(t => t.TransportId == transportId);
            if (!string.IsNullOrEmpty(name))
                hotels = hotels.Where(h => h.Name.Contains(name));

            hotels = sortOrder switch
            {
                SortState.NameDesc => hotels.OrderByDescending(h => h.Name),
                _ => hotels.OrderBy(h => h.Name),
            };

            var count = await hotels.CountAsync();
            var items = await hotels.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel(
                new PageViewModel(count, page, pageSize),
                new SortViewModel(sortOrder),
                new FilterViewModel(db.Hotels.ToList(), db.Transports.ToList(), hotelId, transportId, name),
                items,
                await transports.ToListAsync(),
                name,
                null
            );

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
