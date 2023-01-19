using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Scheduled
{
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
            if (string.IsNullOrEmpty(View.Description))
            {
                ModelState.AddModelError("", "Description name cannot be blank.");
                return Page();
            }
           
           
            if (DateTime.MinValue >= View.StartTime)
            {
                ModelState.AddModelError("", "Birthdate name cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.EndTime)
            {
                ModelState.AddModelError("", "Birthdate name cannot be blank.");
                return Page();
            }


            Appointment appointment = new Appointment()
            {
                ID = Guid.NewGuid(),
                PatientID = Guid.NewGuid(),
                StartTime = View.StartTime,
                EndTime = View.EndTime,
                Description = View.Description,
               
                
            };

            _context?.Appointments?.Add(appointment);
            _context?.SaveChanges();

            return RedirectPermanent("~/Appointment");
        }

        public class ViewModel : Appointment
        {

        }
    }
}
