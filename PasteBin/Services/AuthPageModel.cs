using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
        /// Checks authentication before executing any page handler; unauthenticated requests
        /// are sent straight into the OIDC sign-in flow rather than a local login page
        /// </summary>
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!(HttpContext.User.Identity?.IsAuthenticated ?? false))
                context.Result = Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}