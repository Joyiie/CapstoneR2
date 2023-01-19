using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace CapstoneR2.Pages.Dashboard
{
    [Authorize(Roles = "patient")]
    public class PatientModel : PageModel
    {
       
        public void OnGet()
        {
        }
    }
}
