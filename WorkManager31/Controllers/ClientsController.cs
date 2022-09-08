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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ApplicationDbContext context, ILogger<ClientsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Del")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Del")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Clients/Groups/5
        public async Task<IActionResult> Groups(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            ClientGroupsCheckListViewModel clientGroupsCheckListVM = new ClientGroupsCheckListViewModel();

            List<ClientGroup> allClientGroups = _context.ClientGroup.ToList<ClientGroup>();

            

            foreach (var clientGroup in allClientGroups)
            {
                _logger.LogInformation("ClientGroup: " + clientGroup.Name);

                clientGroupsCheckListVM.clientGroups.Add(clientGroup);

                var match = from clGroupElement in _context.ClientGroupElement
                            where clGroupElement.ClientGroup.Id == clientGroup.Id
                            where clGroupElement.Client.Id == id
                            select new { clGroupElement };

                //clientGroupsCheckListVM.Checks.Add(clientGroup.Id, match.Count()>0);

                //clientGroupsCheckListVM.Checks.Add(clientGroup.Id, true);


                if (match.Count()>0)
                {
                    clientGroupsCheckListVM.Checks.Add(clientGroup.Id, true);
                    
                }
                else
                {
                    clientGroupsCheckListVM.Checks.Add(clientGroup.Id, false);
                    //_logger.LogInformation("Match: " + match.Count());
                } 
                
            }

            clientGroupsCheckListVM.Id = (int)id;
            clientGroupsCheckListVM.Name = client.Name;
            clientGroupsCheckListVM.Description = client.Description;

            //ViewBag.ClientGroupsCheckListVM = clientGroupsCheckListVM;
            
            return View(clientGroupsCheckListVM);
        }

        // POST: Clients/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Groups(int id, ClientGroupsCheckListViewModel clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation("1111111111111111111111111111111111");
                _logger.LogInformation("Id: " + id);
                _logger.LogInformation("clientId: " +clientGroup.Id);
                _logger.LogInformation("Name: "+ clientGroup.Name);
                _logger.LogInformation("Descriptopn:"+clientGroup.Description);
                _logger.LogInformation("Checks:" + clientGroup.Checks.Count);
                _logger.LogInformation("ClientGroup:" + clientGroup);


                
                foreach (var checks in clientGroup.Checks)
                {
                    _logger.LogInformation("222222222222222222222222222222222");
                    Client client = await _context.Client.FindAsync(id);

                    var matchedClientGroupElement = (from clGroupElement in _context.ClientGroupElement
                                where clGroupElement.Client.Id == id
                                where clGroupElement.ClientGroup.Id == checks.Key
                                select clGroupElement);   

                    if (checks.Value) //jesli checkbox jest zaznaczony
                    {
                        _logger.LogInformation("33333333333333333333333333333333333333");
                        if (matchedClientGroupElement == null) //jesli jeszcze brak zaznaczenia w bazie to je dodaj
                        {
                            _logger.LogInformation("4444444444444444444444444444444444444444");
                            ClientGroup addingClientGroup = _context.ClientGroup.Find(checks.Key); 
                            ClientGroupElement clientGroupElement = new ClientGroupElement { Client = client, ClientGroup = addingClientGroup };
                            _context.ClientGroupElement.Add(clientGroupElement);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        if (matchedClientGroupElement != null)
                        {
                            _context.ClientGroupElement.Remove((ClientGroupElement)matchedClientGroupElement);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                //_context.Update(client);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }


    }
}
