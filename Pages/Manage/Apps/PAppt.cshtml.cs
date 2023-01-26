using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain.Security;
using CapstoneR2.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Apps
{
    public class PApptModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PApptModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet()
        {
            Guid? userId = User.Id();
            var user = _context?.Users?.Where(a => a.ID == userId).FirstOrDefault();
            
            var appointments = _context?.Appointments?.Where(a => a.PatientID == user.PatientID).ToList();
            View.Appointments = appointments;
            
        }

        public class ViewModel
        {
            public List<Appointment>? Appointments { get; set; }
        }
    }

}
