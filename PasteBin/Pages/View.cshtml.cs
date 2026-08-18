using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasteBin.Data;
using PasteBin.Models;

namespace PasteBin.Pages
{
    /// <summary>
    /// View paste page
    /// </summary>
    /// <param name="context">Database context</param>
    [Authorize]
    public class ViewModel(AppDbContext context) : PageModel
    {
        /// <summary>
        /// Paste to display
        /// </summary>
        public Paste? Paste { get; set; }

        /// <summary>
        /// Load paste from database
        /// </summary>
        /// <param name="id">Paste ID</param>
        public IActionResult OnGet(int id)
        {
            // Load paste
            Paste = context.Pastes.FirstOrDefault(p => p.Id == id);

            // Return not found if null
            if (Paste is null)
                return NotFound();

            // Return page
            return Page();
        }
    }
}