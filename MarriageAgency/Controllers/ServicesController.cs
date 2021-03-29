using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarriageAgency.Data;
using MarriageAgency.Models;
using MarriageAgency.ViewModels;
using MarriageAgency.ViewModels.Filters;

namespace MarriageAgency.Controllers
{
    public class ServicesController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public ServicesController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index(int? employeeId, bool less30Rub = false, bool more100Rub = false, int page = 1)
        {
            var pageSize = 10;
            var itemCount = _context.Employees.Count();

            IQueryable<Service> services = _context.Services;

            if (employeeId.HasValue && employeeId.Value != 0)
            {
                services = services.Where(s => s.EmployeeId == employeeId);
            }

            if (less30Rub)
            {
                services = services.Where(s => s.Price < 30);
            }

            if (more100Rub)
            {
                services = services.Where(s => s.Price > 100);
            }

            services = services.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(s => s.Customer)
                .Include(s => s.Employee);

            return View(new ServiceViewModel() 
            { 
                Services = await services.ToListAsync(),
                PageViewModel = new PageViewModel(itemCount, page, pageSize),
                ServiceFilter = new ServiceFilter(less30Rub, more100Rub, employeeId, await _context.Employees.ToListAsync())
            });
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Price,CustomerId,EmployeeId")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", service.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", service.EmployeeId);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", service.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", service.EmployeeId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Price,CustomerId,EmployeeId")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", service.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", service.EmployeeId);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
