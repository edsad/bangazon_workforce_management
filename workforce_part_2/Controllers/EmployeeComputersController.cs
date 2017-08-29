using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using workforce_part_2.Models;

namespace workforce_part_2.Controllers
{
    public class EmployeeComputersController : Controller
    {
        private readonly workforce_part_2Context _context;

        public EmployeeComputersController(workforce_part_2Context context)
        {
            _context = context;    
        }

        // GET: EmployeeComputers
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeComputer.ToListAsync());
        }

        // GET: EmployeeComputers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeComputer = await _context.EmployeeComputer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeeComputer == null)
            {
                return NotFound();
            }

            return View(employeeComputer);
        }

        // GET: EmployeeComputers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeComputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ComputerId,StartDate,EndDate")] EmployeeComputer employeeComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeComputer);
        }

        // GET: EmployeeComputers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeComputer = await _context.EmployeeComputer.SingleOrDefaultAsync(m => m.Id == id);
            if (employeeComputer == null)
            {
                return NotFound();
            }
            return View(employeeComputer);
        }

        // POST: EmployeeComputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ComputerId,StartDate,EndDate")] EmployeeComputer employeeComputer)
        {
            if (id != employeeComputer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeComputerExists(employeeComputer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employeeComputer);
        }

        // GET: EmployeeComputers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeComputer = await _context.EmployeeComputer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeeComputer == null)
            {
                return NotFound();
            }

            return View(employeeComputer);
        }

        // POST: EmployeeComputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeComputer = await _context.EmployeeComputer.SingleOrDefaultAsync(m => m.Id == id);
            _context.EmployeeComputer.Remove(employeeComputer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeComputerExists(int id)
        {
            return _context.EmployeeComputer.Any(e => e.Id == id);
        }
    }
}
