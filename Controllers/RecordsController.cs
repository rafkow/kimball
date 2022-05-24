﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kimball.Models;

namespace Kimball.Controllers {
    public class RecordsController :Controller {
        private readonly Context _context;

        public RecordsController(Context context) {
            _context=context;
        }

        // GET: Records
        public async Task<IActionResult> Index() {
            return _context.Records!=null ?
                        View(await _context.Records.ToListAsync()) :
                        Problem("Entity set 'Context.Records'  is null.");
        }

        // GET: Records/Details/5
        public async Task<IActionResult> Details(int? id) {
            if(id==null||_context.Records==null) {
                return NotFound();
            }

            var @record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id==id);
            if(@record==null) {
                return NotFound();
            }

            return View(@record);
        }

        // GET: Records/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value,IsUrgent")] Record @record) {
            if(ModelState.IsValid) {
                _context.Add(@record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@record);
        }

        // GET: Records/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if(id==null||_context.Records==null) {
                return NotFound();
            }

            var @record = await _context.Records.FindAsync(id);
            if(@record==null) {
                return NotFound();
            }
            return View(@record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,Value,IsUrgent")] Record @record) {
            if(id!=@record.Id) {
                return NotFound();
            }

            if(ModelState.IsValid) {
                try {
                    _context.Update(@record);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException) {
                    if(!RecordExists(@record.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@record);
        }

        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if(id==null||_context.Records==null) {
                return NotFound();
            }

            var @record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id==id);
            if(@record==null) {
                return NotFound();
            }

            return View(@record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if(_context.Records==null) {
                return Problem("Entity set 'Context.Records'  is null.");
            }
            var @record = await _context.Records.FindAsync(id);
            if(@record!=null) {
                _context.Records.Remove(@record);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id) {
            return (_context.Records?.Any(e => e.Id==id)).GetValueOrDefault();
        }
    }
}
