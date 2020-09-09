﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace _90311_Rahalevich.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly _90311_Rahalevich.DAL.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(_90311_Rahalevich.DAL.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Insulin Insulin { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insulin = await _context.Insulins
                .Include(i => i.Group).FirstOrDefaultAsync(m => m.InsulinId == id);

            if (Insulin == null)
            {
                return NotFound();
            }
           ViewData["InsulinGroupId"] = new SelectList(_context.InsulinGroups, "InsulinGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Image != null)
            {
                var fileName = $"{Insulin.InsulinId}" + Path.GetExtension(Image.FileName);
                Insulin.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            _context.Attach(Insulin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsulinExists(Insulin.InsulinId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InsulinExists(int id)
        {
            return _context.Insulins.Any(e => e.InsulinId == id);
        }
    }
}
