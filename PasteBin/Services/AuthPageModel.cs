using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PasteBin.Services
{
    /// <summary>
    /// Base page model that requires authentication
    /// </summary>
    public class AuthPageModel : PageModel
    {
        /// <summary>
        /// Checks authentication before executing any page handler
        /// </summary>
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!(HttpContext.User.Identity?.IsAuthenticated ?? false))
                context.Result = RedirectToPage("/Index");
        }
    }
}