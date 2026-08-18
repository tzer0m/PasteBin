using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasteBin.Data;
using PasteBin.Models;

namespace PasteBin.Pages
{
    /// <summary>
    /// New paste page
    /// </summary>
    /// <param name="context">Database context</param>
    [Authorize]
    public class NewModel(AppDbContext context) : PageModel
    {
        /// <summary>
        /// Render the page
        /// </summary>
        public IActionResult OnGet()
        {
            // Return page
            return Page();
        }

        /// <summary>
        /// Save paste to database
        /// </summary>
        /// <param name="content">Paste content</param>
        public async Task<IActionResult> OnPost(string content)
        {
            // Create paste object
            Paste paste = new()
            {
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            // Save object
            context.Pastes.Add(paste);
            await context.SaveChangesAsync();

            // Go to view page
            return RedirectToPage("/View", new { id = paste.Id });
        }
    }
}