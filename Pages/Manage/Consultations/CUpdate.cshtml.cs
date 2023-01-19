using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CapstoneR2.Infrastructure.ViewModel;
using CapstoneR2.Infrastructure.Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Manage.Consultations
{
    [Authorize(Roles = "admin")]
    public class CUpdate : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public CUpdate(DefaultDBContext context, ILogger<Index> logger)
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

            var consultationRecord = _context?.ConsultationRecords?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       ID = a.ID,
                                       Symptoms = a.Symptoms,
                                       DateCreated = a.DateCreated,
                                       DateUpdated = a.DateUpdated,


                                   }).FirstOrDefault();

          

            View = consultationRecord;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.Symptoms))
            {
                ModelState.AddModelError("", "Role name cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.DateCreated)
            {
                ModelState.AddModelError("", "Date Created  cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.DateUpdated)
            {
                ModelState.AddModelError("", "Date Updated cannot be blank.");
                return Page();
            }

          

            var existingConsultationRecord= _context?.ConsultationRecords?.FirstOrDefault(a =>
                    a.ID != View.ID &&
                    a.Symptoms.ToLower() == View.Symptoms.ToLower()
                    
                    



            );

            if (existingConsultationRecord != null)
            {
                ModelState.AddModelError("", "Role is already existing.");
                return Page();
            }

            var consultationRecord = _context?.ConsultationRecords?.FirstOrDefault(a => a.ID == View.ID);

            if (consultationRecord != null)
            {
                consultationRecord.Symptoms= View.Symptoms;
                consultationRecord.DateCreated = View.DateCreated;
                consultationRecord.DateUpdated = View.DateUpdated;
                

                _context?.ConsultationRecords?.Update(consultationRecord);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/patients");
            }

            return Page();

        }

        public class ViewModel : ConsultationRecord
        {

        }
    }
}


