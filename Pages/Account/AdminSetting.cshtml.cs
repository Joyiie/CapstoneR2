using CapstoneR2.Infrastructure.Domain.Security;
using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Account
{
    [Authorize(Roles = "admin")]
    public class AdminSettingModel : PageModel
    {

        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public AdminSettingModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public IActionResult OnGet(Guid? id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context?.Users?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       FirstName = a.FirstName,
                                       MiddleName = a.MiddleName,
                                       LastName = a.LastName,
                                       BirthDate = a.BirthDate,
                                       Address = a.Address,

                                   }).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            View = user;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.FirstName))
            {
                ModelState.AddModelError("", "Role name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.MiddleName))
            {
                ModelState.AddModelError("", "Role name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.LastName))
            {
                ModelState.AddModelError("", "Role name cannot be blank.");
                return Page();
            }

            if (string.IsNullOrEmpty(View.Address))
            {
                ModelState.AddModelError("", "Description cannot be blank.");
                return Page();
            }


            var existingUser = _context?.Patients?.FirstOrDefault(a =>
                    a.FirstName.ToLower() == View.FirstName.ToLower() &&
                    a.LastName.ToLower() == View.LastName.ToLower() &&
                    a.MiddleName.ToLower() == View.MiddleName.ToLower() &&
                    a.Address.ToLower() == View.Address.ToLower()






            );

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Patient is already existing.");
                return Page();
            }

            var user = _context?.Users?.FirstOrDefault(a => a.ID == User.Id());

           

            if (user != null)
            {

               
                user.FirstName = View.FirstName;
                user.MiddleName = View.MiddleName;
                user.LastName = View.LastName;
                user.Address = View.Address;




               
                _context?.Users?.Update(user);
                _context?.SaveChanges();

                return RedirectPermanent("~/dashboard/admin");
            }

            return Page();

        }

        public class ViewModel : UserViewModel
        {

        }
    }
}
