using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CapstoneR2.Infrastructure.Domain.Models;


namespace CapstoneR2.Pages.Dashboard
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        
        public void OnGet()
        {
        }
    }
}
