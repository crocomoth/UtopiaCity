using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration.ResidentAccount;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class RersidentAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RersidentAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RersidentAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RersidentAccount.ToListAsync());
        }

        // GET: RersidentAccounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rersidentAccount = await _context.RersidentAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rersidentAccount == null)
            {
                return NotFound();
            }

            return View(rersidentAccount);
        }

        // GET: RersidentAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RersidentAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,FamilyName,BirthDate,Gender")] RersidentAccount rersidentAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rersidentAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rersidentAccount);
        }

        // GET: RersidentAccounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rersidentAccount = await _context.RersidentAccount.FindAsync(id);
            if (rersidentAccount == null)
            {
                return NotFound();
            }
            return View(rersidentAccount);
        }

        // POST: RersidentAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,FamilyName,BirthDate,Gender")] RersidentAccount rersidentAccount)
        {
            if (id != rersidentAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rersidentAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RersidentAccountExists(rersidentAccount.Id))
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
            return View(rersidentAccount);
        }

        // GET: RersidentAccounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rersidentAccount = await _context.RersidentAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rersidentAccount == null)
            {
                return NotFound();
            }

            return View(rersidentAccount);
        }

        // POST: RersidentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rersidentAccount = await _context.RersidentAccount.FindAsync(id);
            _context.RersidentAccount.Remove(rersidentAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RersidentAccountExists(string id)
        {
            return _context.RersidentAccount.Any(e => e.Id == id);
        }
    }
}
