using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Manage.Consultations
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

        public IActionResult OnPost(Guid? id = null)
        {
           
            Guid CRGuid = Guid.NewGuid();
            var appts = _context?.Appointments?.FirstOrDefault(a => a.ID == id);
      




            if (DateTime.MinValue >= View.DateCreated)
            {
                ModelState.AddModelError("", "DateTime cannot be blank.");
                return Page();
            }
           

            if (string.IsNullOrEmpty(View.FTags))
            {
                ModelState.AddModelError("", "Finding Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.FDescription))
            {
                ModelState.AddModelError("", "Finding Description name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.PTags))
            {
                ModelState.AddModelError("", "Prescription Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.PDescription))
            {
                ModelState.AddModelError("", "Prescription Description name cannot be blank.");
                return Page();
            }

            ConsultationRecord consultationRecords = new ConsultationRecord()
            {
                ID = CRGuid,
                AppointmentID = id,
                DateCreated = View.DateCreated,
                DateUpdated = View.DateUpdated,
                PatientID = appts.PatientID
            };
            Infrastructure.Domain.Models.Prescription prescription = new Infrastructure.Domain.Models.Prescription()
            {
                ID = Guid.NewGuid(),
                ConsultationRecordID = CRGuid,
                Tags = View.PTags,
                Description = View.PDescription
            };
            Finding finding = new Finding()
            {
                ID = Guid.NewGuid(),
                ConsultationRecordID = CRGuid,
                Tags = View.FTags,
                Description = View.FDescription
            };
            _context?.Findings?.Add(finding);
            _context?.Prescriptions?.Add(prescription);
            _context?.ConsultationRecords?.Add(consultationRecords);
            _context?.SaveChanges();

            return RedirectPermanent("~/manage/consultations/visitrecord");
        }

        public class ViewModel : CRViewModel
        {

        }


    }
}
