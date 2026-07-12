using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PasteBin.Pages
{
    /// <summary>
    /// Login page
    /// </summary>
    /// <param name="configuration">Configuration</param>
    public class IndexModel(IConfiguration configuration) : PageModel
    {
        /// <summary>
        /// Whether the password was incorrect
        /// </summary>
        public bool Error { get; set; } = false;

        /// <summary>
        /// If already authenticated, skip the login form and go straight to the pastes list
        /// </summary>
        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity?.IsAuthenticated ?? false)
                return RedirectToPage("/Pastes/Index");

            return Page();
        }

        /// <summary>
        /// Check password and, if correct, sign in with a persistent cookie and redirect
        /// </summary>
        public async Task<IActionResult> OnPost(string password)
        {
            if (password != configuration["Password"])
            {
                Error = true;
                return Page();
            }

            // Build a minimal identity - no roles or user-specific claims needed, just proof of a successful login
            ClaimsIdentity identity = new ClaimsIdentity([new Claim(ClaimTypes.Name, "PasteBinUser")], CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // IsPersistent + the cookie's own ExpireTimeSpan (set in Program.cs) is what makes this survive browser restarts
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

            return RedirectToPage("/Pastes/Index");
        }
    }
}