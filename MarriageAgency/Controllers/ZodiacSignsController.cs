using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarriageAgency.Data;
using MarriageAgency.Models;

namespace MarriageAgency.Controllers
{
    public class ZodiacSignsController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public ZodiacSignsController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: ZodiacSigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZodiacSigns.ToListAsync());
        }

        // GET: ZodiacSigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zodiacSign = await _context.ZodiacSigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zodiacSign == null)
            {
                return NotFound();
            }

            return View(zodiacSign);
        }

        // GET: ZodiacSigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZodiacSigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Description")] ZodiacSign zodiacSign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zodiacSign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zodiacSign);
        }

        // GET: ZodiacSigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zodiacSign = await _context.ZodiacSigns.FindAsync(id);
            if (zodiacSign == null)
            {
                return NotFound();
            }
            return View(zodiacSign);
        }

        // POST: ZodiacSigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Description")] ZodiacSign zodiacSign)
        {
            if (id != zodiacSign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zodiacSign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZodiacSignExists(zodiacSign.Id))
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
            return View(zodiacSign);
        }

        // GET: ZodiacSigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zodiacSign = await _context.ZodiacSigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zodiacSign == null)
            {
                return NotFound();
            }

            return View(zodiacSign);
        }

        // POST: ZodiacSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zodiacSign = await _context.ZodiacSigns.FindAsync(id);
            _context.ZodiacSigns.Remove(zodiacSign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZodiacSignExists(int id)
        {
            return _context.ZodiacSigns.Any(e => e.Id == id);
        }
    }
}
