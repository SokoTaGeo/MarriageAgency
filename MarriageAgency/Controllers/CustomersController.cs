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
    public class CustomersController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public CustomersController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(int? zodiacSignId, int page = 1)
        {
            var pageSize = 10;
            var itemCount = _context.Customers.Count();

            IQueryable<Customer> customers = _context.Customers;

            if (zodiacSignId.HasValue && zodiacSignId.Value != 0)
            {
                customers = customers.Where(c => c.ZodiacSignId == zodiacSignId);
            }

            customers = customers.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(c => c.Nationality)
                .Include(c => c.Relationship)
                .Include(c => c.ZodiacSign);

            return View(new CustomerViewModel()
            {
                Customers = await customers.ToListAsync(),
                PageViewModel = new PageViewModel(itemCount, page, pageSize),
                CustomerFilter = new CustomerFilter(zodiacSignId, await _context.ZodiacSigns.ToListAsync())
            });
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Nationality)
                .Include(c => c.Relationship)
                .Include(c => c.ZodiacSign)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
            ViewData["RelationshipId"] = new SelectList(_context.Relationships, "Id", "Name");
            ViewData["ZodiacSignId"] = new SelectList(_context.ZodiacSigns, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Sex,BirthdayDate,Age,Height,Weight,ChildrenCount,MaritalStatus,BadHadits,Hobby,Description,ZodiacSignId,RelationshipId,NationalityId,Address,PhoneNumber,PassportData")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name", customer.NationalityId);
            ViewData["RelationshipId"] = new SelectList(_context.Relationships, "Id", "Name", customer.RelationshipId);
            ViewData["ZodiacSignId"] = new SelectList(_context.ZodiacSigns, "Id", "Name", customer.ZodiacSignId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name", customer.NationalityId);
            ViewData["RelationshipId"] = new SelectList(_context.Relationships, "Id", "Name", customer.RelationshipId);
            ViewData["ZodiacSignId"] = new SelectList(_context.ZodiacSigns, "Id", "Name", customer.ZodiacSignId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Sex,BirthdayDate,Age,Height,Weight,ChildrenCount,MaritalStatus,BadHadits,Hobby,Description,ZodiacSignId,RelationshipId,NationalityId,Address,PhoneNumber,PassportData")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name", customer.NationalityId);
            ViewData["RelationshipId"] = new SelectList(_context.Relationships, "Id", "Name", customer.RelationshipId);
            ViewData["ZodiacSignId"] = new SelectList(_context.ZodiacSigns, "Id", "Name", customer.ZodiacSignId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Nationality)
                .Include(c => c.Relationship)
                .Include(c => c.ZodiacSign)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
