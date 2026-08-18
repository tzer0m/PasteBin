using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasteBin.Data;
using PasteBin.Models;

namespace PasteBin.Pages
{
    /// <summary>
    /// Pastes list page
    /// </summary>
    /// <param name="context">Database context</param>
    [Authorize]
    public class IndexModel(AppDbContext context) : PageModel
    {
        /// <summary>
        /// List of pastes
        /// </summary>
        public List<Paste> Pastes { get; set; } = [];

        /// <summary>
        /// Load pastes from database
        /// </summary>
        public IActionResult OnGet()
        {
            // Load pastes
            Pastes = [.. context.Pastes.OrderByDescending(p => p.CreatedAt)];
            return Page();
        }
    }
}