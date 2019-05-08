using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scientific_report.Models;

namespace Scientific_report.Controllers
{
    public class Work_UserController : Controller
    {
        private readonly AppReportContext _context;

        public Work_UserController(AppReportContext context)
        {
            _context = context;
        }

        // GET: Work_User
        public async Task<IActionResult> Index(int ID)
        {
            var appReportContext = _context.Work_Users.Include(w => w.Work).Where(p=>p.UserId==ID);
            return View(await appReportContext.ToListAsync());
        }

        // GET: Work_User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work_User = await _context.Work_Users
                .Include(w => w.Work)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work_User == null)
            {
                return NotFound();
            }

            return View(work_User);
        }

        // GET: Work_User/Create
        public IActionResult Create()
        {
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Id");
            return View();
        }

        // POST: Work_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkId,UserId")] Work_User work_User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(work_User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Id", work_User.WorkId);
            return View(work_User);
        }

        // GET: Work_User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work_User = await _context.Work_Users.FindAsync(id);
            if (work_User == null)
            {
                return NotFound();
            }
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Id", work_User.WorkId);
            return View(work_User);
        }

        // POST: Work_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkId,UserId")] Work_User work_User)
        {
            if (id != work_User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work_User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Work_UserExists(work_User.Id))
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
            ViewData["WorkId"] = new SelectList(_context.Works, "Id", "Id", work_User.WorkId);
            return View(work_User);
        }

        // GET: Work_User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work_User = await _context.Work_Users
                .Include(w => w.Work)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work_User == null)
            {
                return NotFound();
            }

            return View(work_User);
        }

        // POST: Work_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work_User = await _context.Work_Users.FindAsync(id);
            _context.Work_Users.Remove(work_User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Work_UserExists(int id)
        {
            return _context.Work_Users.Any(e => e.Id == id);
        }
    }
}
