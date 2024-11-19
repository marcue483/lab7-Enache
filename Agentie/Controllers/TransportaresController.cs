using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agentie.Data;
using Agentie.Models;

namespace Agentie.Controllers
{
    public class TransportsController : Controller
    {
        private readonly AgentieContext _context;

        public TransportsController(AgentieContext context)
        {
            _context = context;
        }

        // GET: Transports
        public async Task<IActionResult> Index()
        {
            var agentieContext = _context.Transports.Include(t => t.Client);
            return View(await agentieContext.ToListAsync());
        }

        // GET: Transports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportare = await _context.Transports
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transportare == null)
            {
                return NotFound();
            }

            return View(transportare);
        }

        // GET: Transports/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Mail");
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ClientId,Price,Data,PersonNR")] Transportare transportare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Mail", transportare.ClientId);
            return View(transportare);
        }

        // GET: Transports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportare = await _context.Transports.FindAsync(id);
            if (transportare == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Mail", transportare.ClientId);
            return View(transportare);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ClientId,Price,Data,PersonNR")] Transportare transportare)
        {
            if (id != transportare.TransportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportareExists(transportare.TransportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Mail", transportare.ClientId);
            return View(transportare);
        }

        // GET: Transports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportare = await _context.Transports
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.TransportId == id);
            if (transportare == null)
            {
                return NotFound();
            }

            return View(transportare);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportare = await _context.Transports.FindAsync(id);
            if (transportare != null)
            {
                _context.Transports.Remove(transportare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportareExists(int id)
        {
            return _context.Transports.Any(e => e.TransportId == id);
        }
    }
}
