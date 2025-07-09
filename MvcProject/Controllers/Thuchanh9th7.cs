using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class Thuchanh9th7 : Controller
    {
        private readonly ApplicationDbContext _context;
        private static readonly string PersonId;

        public Thuchanh9th7(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Thuchanh9th7
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thuchanh9th7.ToListAsync());
        }

        // GET: Thuchanh9th7/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchanh9th7 = await _context.Thuchanh9th7
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (thuchanh9th7 == null)
            {
                return NotFound();
            }

            return View(thuchanh9th7);
        }

        // GET: Thuchanh9th7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thuchanh9th7/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId")] Person ps)
        {
            if (ModelState.IsValid)
            {
              
                string newId = "PS000";

                int number = int.Parse(newId.Substring(2)) + 1; //chuyển số nguyên thành số thêm 1
                newId = "PS" + number.ToString("D3"); //thành chuỗi  có 3 chữ số

                ps.PersonId = newId; 

                _context.Add(ps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(ps);
        }

        // GET: Thuchanh9th7/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchanh9th7 = await _context.Thuchanh9th7.FindAsync(id);
            if (thuchanh9th7 == null)
            {
                return NotFound();
            }
            return View(thuchanh9th7);
        }

        // POST: Thuchanh9th7/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId")] Thuchanh9th7 thuchanh9th7)
        {
            if (id != thuchanh9th7.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuchanh9th7);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Thuchanh9th7Exists(thuchanh9th7.PersonId))
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
            return View(thuchanh9th7);
        }

        // GET: Thuchanh9th7/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuchanh9th7 = await _context.Thuchanh9th7
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (thuchanh9th7 == null)
            {
                return NotFound();
            }

            return View(thuchanh9th7);
        }

        // POST: Thuchanh9th7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thuchanh9th7 = await _context.Thuchanh9th7.FindAsync(id);
            if (thuchanh9th7 != null)
            {
                _context.Thuchanh9th7.Remove(thuchanh9th7);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Thuchanh9th7Exists(string id)
        {
            return _context.Thuchanh9th7.Any(e => e.PersonId == id);
        }
    }
}
