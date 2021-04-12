using Microsoft.AspNetCore.Mvc.RazorPages;

namespace oh7.CspEditor.Core5.WebApp.Pages
{
    public class BasePageModel : PageModel
    {
        public string GetUserId => User.GetLoggedInUserId<string>();
    }
}