using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IBankingBlazorSSR.Web;

public class CookieEvents : CookieAuthenticationEvents
{
    public override Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
    {
        context.RedirectUri = "/Identity/Login";
        return base.RedirectToLogin(context);
    }
}