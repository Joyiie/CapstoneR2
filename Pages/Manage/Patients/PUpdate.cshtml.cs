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
    public class PUpdate : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PUpdate(DefaultDBContext context, ILogger<Index> logger)
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

            var patient = _context?.Patients?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       ID = a.ID,
                                       FirstName = a.FirstName,
                                       MiddleName = a.MiddleName,
                                       LastName = a.LastName,
                                       Gender = a.Gender,
                                       BirthDate = a.BirthDate,
                                       Address = a.Address,
                                       ContactNo = a.ContactNo
                                   }).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }

            View = patient;
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
            if (string.IsNullOrEmpty(View.ContactNo))
            {
                ModelState.AddModelError("", "Role name cannot be blank.");
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

            var existingPatient = _context?.Patients?.FirstOrDefault(a =>
                    a.ID != View.ID &&
                    a.FirstName.ToLower() == View.FirstName.ToLower()&&
                    a.LastName.ToLower() == View.LastName.ToLower()&&
                    a.MiddleName.ToLower() == View.MiddleName.ToLower() &&
                    a.Address.ToLower() == View.Address.ToLower() &&
                    a.ContactNo.ToLower() == View.ContactNo.ToLower() 
                   



            );

            if (existingPatient != null)
            {
                ModelState.AddModelError("", "Role is already existing.");
                return Page();
            }

            var patient = _context?.Patients?.FirstOrDefault(a => a.ID == View.ID);

            if (patient != null)
            {
                patient.FirstName = View.FirstName;
                patient.MiddleName = View.MiddleName;
                patient.LastName = View.LastName;
                patient.BirthDate = View.BirthDate;
                patient.Address = View.Address;
                patient.Gender = View.Gender;
                patient.ContactNo = View.ContactNo;

                _context?.Patients?.Update(patient);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/patients");
            }

            return Page();

        }

        public class ViewModel : Patient
        {

        }
    }
}
