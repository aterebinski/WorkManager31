using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkManager31.Data;
using WorkManager31.Models;

namespace WorkManager31.Controllers
{
    public class ClientGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClientGroupsController> _logger;

        public ClientGroupsController(ApplicationDbContext context, ILogger<ClientGroupsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: ClientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientGroup.ToListAsync());
        }

        // GET: ClientGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // GET: ClientGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Del")] ClientGroup clientGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientGroup);
        }

        // GET: ClientGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientGroup.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            return View(clientGroup);
        }

        // POST: ClientGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Del")] ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientGroupExists(clientGroup.Id))
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
            return View(clientGroup);
        }

        public async Task<IActionResult> Clients(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientGroup.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            ClientsCheckListViewModel clientsCheckListViewModel = new ClientsCheckListViewModel();

            var matchClients = (from clGroupElement in _context.ClientGroupElement
                                                 where clGroupElement.ClientGroup.Id == id
                                                 select clGroupElement.Client.Id);


            clientsCheckListViewModel.Clients = _context.Client.OrderBy(c => c.Name).ToList();

            foreach (var client in clientsCheckListViewModel.Clients)
            {
                bool match;
                int? matchId = (from mc in matchClients
                                where mc == client.Id
                                select mc).FirstOrDefault();
                _logger.LogInformation("================> is: " + matchId);

                match = matchId != 0;

                clientsCheckListViewModel.Checks.Add(client.Id, match);
            }


            clientsCheckListViewModel.Id = id;
            clientsCheckListViewModel.Name = clientGroup.Name;
            clientsCheckListViewModel.Description = clientGroup.Description;

            return View(clientsCheckListViewModel);
        }

        // POST: ClientGroups/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clients(int id, [Bind("Id,Name,Description")] ClientsCheckListViewModel clientsCheckListViewModel)
        {
            if (id != clientsCheckListViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                List<Client> allClients = _context.Client.ToList();
                for (int i = 0; i < allClients.Count ; i++)
                {
                    if (clientsCheckListViewModel.Checks[i])
                    {

                    }
                }





               
            }
            return View(clientsCheckListViewModel);
        }

        // GET: ClientGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // POST: ClientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientGroup = await _context.ClientGroup.FindAsync(id);
            _context.ClientGroup.Remove(clientGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientGroupExists(int id)
        {
            return _context.ClientGroup.Any(e => e.Id == id);
        }
    }
}
