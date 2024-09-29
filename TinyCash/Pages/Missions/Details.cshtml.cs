using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TinyCash.Data;
using TinyCash.Models;

namespace TinyCash.Pages.Missions
{
    public class DetailsModel : PageModel
    {
        private readonly TinyCash.Data.HomeContext _context;

        public DetailsModel(TinyCash.Data.HomeContext context)
        {
            _context = context;
        }

        public Mission Mission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _context.Mission.FirstOrDefaultAsync(m => m.ID == id);
            if (mission == null)
            {
                return NotFound();
            }
            else
            {
                Mission = mission;
            }
            return Page();
        }
    }
}
