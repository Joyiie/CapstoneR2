using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain.Security;
using CapstoneR2.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CapstoneR2.Pages.Manage.Patients
{
    [Authorize(Roles = "patient")]
    public class ChangePassModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public ChangePassModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public IActionResult OnGet(Guid? id = null)
        {
            return Page();
     
        }

        public IActionResult OnPost()
        {

            if (string.IsNullOrEmpty(View.CurrentPass))
            {
                ModelState.AddModelError("", "Field Required");
                return Page();
            }

            if (string.IsNullOrEmpty(View.NewPass))
            {
                ModelState.AddModelError("", "Field Required");
                return Page();
            }

            if (string.IsNullOrEmpty(View.RetypedPassword))
            {
                ModelState.AddModelError("", "Field Required");
                return Page();
            }

            if (View.NewPass != View.RetypedPassword)
            {
                ModelState.AddModelError("", "Passwords are not the same");
                return Page();
            }


            var passwordInfo = _context?.UserLogins?.FirstOrDefault(a => a.UserID == User.Id() && a.Key.ToLower() == "password");

            if (passwordInfo != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(View.CurrentPass, passwordInfo.Value))
                {
                    var userRole = _context?.UserRoles?.Include(a => a.Role)!.FirstOrDefault(a => a.UserID == User.Id());

                    passwordInfo.Value = BCrypt.Net.BCrypt.EnhancedHashPassword(View.NewPass);
                   _context?.UserLogins?.Update(passwordInfo);
                   _context?.SaveChanges();

                    if (userRole!.Role!.Name.ToLower() == "admin")
                    {
                        return RedirectPermanent("/dashboard/admin");
                    }
                    else
                    {
                        return RedirectPermanent("/dashboard/patient");
                    }
                }
            }
            return Page();
        }

        public class  ViewModel 
        {
          public string? CurrentPass { get; set; }
          public string? NewPass  {get; set; }
          public string? RetypedPassword { get; set; }
        }
    }
}
