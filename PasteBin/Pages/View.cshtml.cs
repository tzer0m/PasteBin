using Microsoft.AspNetCore.Mvc;
using PasteBin.Data;
using PasteBin.Models;
using PasteBin.Services;

namespace PasteBin.Pages
{
    /// <summary>
    /// View paste page
    /// </summary>
    /// <param name="context">Database context</param>
    public class ViewModel(AppDbContext context) : AuthPageModel
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