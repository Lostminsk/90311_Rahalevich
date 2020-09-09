using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;

namespace _90311_Rahalevich.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly _90311_Rahalevich.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(_90311_Rahalevich.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Insulin Insulin { get; set; }

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
            return Page();
        }
    }
}
