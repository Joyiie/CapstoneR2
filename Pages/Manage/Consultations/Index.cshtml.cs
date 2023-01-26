using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using CapstoneR2.Infrastructure.Domain.Security;
using Microsoft.EntityFrameworkCore;

namespace CapstoneR2.Pages.Manage.Consultations
{
    [Authorize(Roles = "admin")]
    public class Index : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Index(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet(Guid? id = null,Guid? crid = null)

        {
            ViewData["id"] = id;
            var user = _context?.Users?.Where(a => a.ID == id).FirstOrDefault();
            if (user != null)
            {
                Guid? patientId = user.PatientID;
                var patientConsultation = _context?.ConsultationRecords?.Where(a => a.PatientID == patientId).Include(a => a.Patient).Include(a => a.Appointment).ToList();
                View.ConsultationRecords = patientConsultation;

                var findings = _context?.Findings?.Where(a => a.ConsultationRecordID == crid).FirstOrDefault();
                var prescriptions = _context?.Prescriptions?.Where(a => a.ConsultationRecordID == crid).FirstOrDefault();


                if (findings != null && prescriptions != null)
                {


                    ViewData["pdsc"] = prescriptions.Description;
                    ViewData["ptags"] = prescriptions.Tags;
                    ViewData["fdsc"] = findings.Description;
                    ViewData["ftags"] = findings.Tags;

                }
            }
        }
        public class ViewModel
        {
            public List<ConsultationRecord>? ConsultationRecords { get; set; }
        }
    }
}
