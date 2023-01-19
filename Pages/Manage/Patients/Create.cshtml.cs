using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CapstoneR2.Infrastructure.Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Manage.Patients
{
    [Authorize(Roles = "admin")]
    public class Create : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Create(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.FirstName))
            {
                ModelState.AddModelError("", "First name cannot be blank.");
                return Page();
            }

            if (string.IsNullOrEmpty(View.MiddleName))
            {
                ModelState.AddModelError("", "Middle name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.LastName))
            {
                ModelState.AddModelError("", "Last name cannot be blank.");
                return Page();
            }
            if (!Enum.IsDefined(typeof(Gender), View.Gender))
            {
                ModelState.AddModelError("", "Sex name cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.BirthDate)
            {
                ModelState.AddModelError("", "Birthdate name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.ContactNo))
            {
                ModelState.AddModelError("", "Contact NO name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.Address))
            {
                ModelState.AddModelError("", "Address name cannot be blank.");
                return Page();
            }
            Patient patient = new Patient()
            {
                ID = Guid.NewGuid(),
                FirstName = View.FirstName,
                MiddleName= View.MiddleName,
                LastName = View.LastName,
                Gender = View.Gender,
                BirthDate = View.BirthDate,
                ContactNo= View.ContactNo,
                Address = View.Address
            };

            _context?.Patients?.Add(patient);
            _context?.SaveChanges();

            return RedirectPermanent("~/manage/patients");
        }

        public class ViewModel : Patient
        {

        }
    }
}
