using Microsoft.AspNetCore.Mvc;
using PasteBin.Data;
using PasteBin.Models;
using PasteBin.Services;

namespace PasteBin.Pages
{
    /// <summary>
    /// Pastes list page
    /// </summary>
    /// <param name="context">Database context</param>
    public class IndexModel(AppDbContext context) : AuthPageModel
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