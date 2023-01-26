using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Apps
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public EditModel(DefaultDBContext context, ILogger<Index> logger)
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

            var appointment = _context?.Appointments?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       ID = a.ID,
                                       Symptom = a.Symptom,
                                       StartTime = a.StartTime,
                                       EndTime = a.EndTime,


                                   }).FirstOrDefault();



            View = appointment;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.Symptom))
            {
                ModelState.AddModelError("", "Symptoms cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.StartTime)
            {
                ModelState.AddModelError("", "StartTime   cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.EndTime)
            {
                ModelState.AddModelError("", "Endtime cannot be blank.");
                return Page();
            }



            var existingAppointment = _context?.Appointments?.FirstOrDefault(a =>
                    a.ID != View.ID &&
                    a.Symptom.ToLower() == View.Symptom.ToLower()





            );

            if (existingAppointment != null)
            {
                ModelState.AddModelError("", "Role is already existing.");
                return Page();
            }

            var appointment = _context?.Appointments?.FirstOrDefault(a => a.ID == View.ID);

            if (appointment != null)
            {
                appointment.Symptom = View.Symptom;
                appointment.StartTime = View.StartTime;
                appointment.EndTime = View.EndTime;


                _context?.Appointments?.Update(appointment);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/apps/appt");
            }

            return Page();

        }

        public class ViewModel : Appointment
        {

        }
    }
}


