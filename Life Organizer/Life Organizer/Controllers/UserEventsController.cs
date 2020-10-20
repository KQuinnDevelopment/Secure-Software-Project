// I, Quinn Helm, student number 000737479, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Life_Organizer.Data;
using Life_Organizer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Life_Organizer.Controllers
{
    [Authorize]
    public class UserEventsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserEventsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: UserEvents
        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserId(User);

            if (user != null)
            {
                var events = from ev in _context.Events
                             select ev;
                var uEvents = events.Where(i => i.UserID == user);
                return View(await uEvents.ToListAsync());
            } else
            {
                return NotFound();
            }
        }

        // GET: UserEvents
        public async Task<IActionResult> Upcoming()
        {
            var user = _userManager.GetUserId(User);

            if (user != null)
            {
                var events = from ev in _context.Events
                             select ev;
                var uEvents = events.Where(i => i.UserID == user).Where(x => x.Date >= DateTime.Now);
                return View(await uEvents.ToListAsync());
            }
            else
            {
                return NotFound();
            }
        }

        // GET: UserEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // GET: UserEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Date,Description,Duration")] UserEvent userEvent)
        {
            ModelState.Remove("UserID");
            userEvent.UserID = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                _context.Add(userEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEvent);
        }

        // GET: UserEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.Events.FindAsync(id);
            if (userEvent == null)
            {
                return NotFound();
            }
            return View(userEvent);
        }

        // POST: UserEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Name,Date,Description,Duration")] UserEvent userEvent)
        {
            if (id != userEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventExists(userEvent.Id))
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
            return View(userEvent);
        }

        // GET: UserEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // POST: UserEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEvent = await _context.Events.FindAsync(id);
            _context.Events.Remove(userEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
