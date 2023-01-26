using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CapstoneR2.Pages.Account;
using CapstoneR2.Infrastructure.Domain.Security;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using CapstoneR2.Infrastructure.ViewModel;

namespace CapstoneR2.Pages.Manage.Patients
{
    [Authorize(Roles = "patient")]
    public class ViewRecordsModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }



        public ViewRecordsModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();

        }

        public void OnGet(Guid? id = null)

        {
            Guid? userId = User.Id();
            var user = _context?.Users?.Where(a => a.ID == userId).FirstOrDefault();

            Guid? patientId = user.PatientID;
            var patientConsultation = _context?.ConsultationRecords?.Where(a => a.PatientID == patientId).ToList();
            View.ConsultationRecords = patientConsultation;

            var findings = _context?.Findings?.Where(a => a.ConsultationRecordID == id).FirstOrDefault();
            var prescriptions = _context?.Prescriptions?.Where(a => a.ConsultationRecordID == id).FirstOrDefault();


            if ( findings != null && prescriptions != null)
            { 


             ViewData["pdsc"]    = prescriptions.Description;
             ViewData["ptags"]  = prescriptions.Tags;
             ViewData["fdsc"]      = findings.Description;
             ViewData["ftags"]  = findings.Tags;

            }
        }



        public class ViewModel
        {
            public List<ConsultationRecord>? ConsultationRecords { get; set; }
        }
    }

}
