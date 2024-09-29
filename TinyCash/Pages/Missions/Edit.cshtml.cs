using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TinyCash.Data;
using TinyCash.Models;

namespace TinyCash.Pages.Missions
{
    public class EditModel : PageModel
    {
        private readonly TinyCash.Data.HomeContext _context;

        public EditModel(TinyCash.Data.HomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mission Mission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission =  await _context.Mission.FirstOrDefaultAsync(m => m.ID == id);
            if (mission == null)
            {
                return NotFound();
            }
            Mission = mission;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(Mission.ID))
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

        private bool MissionExists(int id)
        {
            return _context.Mission.Any(e => e.ID == id);
        }
    }
}
