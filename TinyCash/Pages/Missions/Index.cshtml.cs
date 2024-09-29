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
    public class IndexModel : PageModel
    {
        private readonly TinyCash.Data.HomeContext _context;

        public IndexModel(TinyCash.Data.HomeContext context)
        {
            _context = context;
        }

        public IList<Mission> Mission { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Mission = await _context.Mission.ToListAsync();
        }
    }
}
