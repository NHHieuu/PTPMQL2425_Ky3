using Microsoft.AspNetCore.Mvc;
using MvcProject.Data;
using MvcProject.Models;
using MvcProject.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MvcProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            //1. Lay ra ban ghi moi nhat cua Person
            var person = _context.Persons.OrderByDescending(p => p.PersonID).FirstOrDefault();
            //2. Neu person == null thi gan PersonID = PS0
            var personID = person == null ? "PS0" : person.PersonID;
            //3. Goi toi phuong thuc sinh id tu dong
            var autoGenerateId = new AutoGenerateId();
            var newPersonID = autoGenerateId.GenerateId(personID);
            var newPerson = new Person
            {
                PersonID = newPersonID
            };
            return View(newPerson);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();

            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address,Email")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
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
            return View(person);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");

            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); ;
        }
        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }

    }
} 
