using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Manage.Patients
{
    [Authorize(Roles = "admin")]
    public class PDelete : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PDelete(DefaultDBContext context, ILogger<Index> logger)
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
                                       ContactNo =a.ContactNo
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
            if (View.ID == null)
            {
                return NotFound();
            }

            var patient = _context?.Patients?.FirstOrDefault(a => a.ID == View.ID);

            if (patient != null)
            {
                _context?.Patients?.Remove(patient);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/Patients");
            }

            return NotFound();

        }

        public class ViewModel : Patient
        {

        }
    }
}
