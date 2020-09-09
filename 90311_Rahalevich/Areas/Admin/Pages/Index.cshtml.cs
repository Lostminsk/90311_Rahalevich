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
    public class IndexModel : PageModel
    {
        private readonly _90311_Rahalevich.DAL.Data.ApplicationDbContext _context;

        public IndexModel(_90311_Rahalevich.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Insulin> Insulin { get;set; }

        public async Task OnGetAsync()
        {
            Insulin = await _context.Insulins
                .Include(i => i.Group).ToListAsync();
        }
    }
}
