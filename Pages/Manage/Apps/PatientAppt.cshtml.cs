using CapstoneR2.Infrastructure.Domain.Models.Enums;
using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CapstoneR2.Infrastructure.Domain.Security;

namespace CapstoneR2.Pages.Manage.Apps
{
    [Authorize(Roles = "patient")]
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
            Guid? userId = User.Id();
            var user = _context?.Users?.Where(a => a.ID == userId).FirstOrDefault();

            Guid? patientId = user.PatientID;
            
           

            if (string.IsNullOrEmpty(View.Symptom))
            {
                ModelState.AddModelError("", "First name cannot be blank.");
                return Page();
            }

           
            if (DateTime.MinValue >= View.StartTime)
            {
                ModelState.AddModelError("", "Start cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.EndTime)
            {
                ModelState.AddModelError("", "End cannot be blank.");
                return Page();
            }

            DateTime? endTime = View.StartTime.Value.AddHours(1);

            View.ID = Guid.NewGuid();
            Appointment appointment = new Appointment()
            {
                ID = View.ID,
                PatientID = patientId,
                Symptom = View.Symptom,
                StartTime = View.StartTime,
                EndTime = endTime                             
            };

            _context?.Appointments?.Add(appointment);
            _context?.SaveChanges();

            return RedirectPermanent("~/QrCode/Generator?id=" + View.ID);
        }

        public class ViewModel : Appointment
        {

        }
    }
}