using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace _90311_Rahalevich.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly _90311_Rahalevich.DAL.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(_90311_Rahalevich.DAL.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["InsulinGroupId"] = new SelectList(_context.InsulinGroups, "InsulinGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Insulin Insulin { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Insulins.Add(Insulin);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Insulin.InsulinId}" + Path.GetExtension(Image.FileName);
                Insulin.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
