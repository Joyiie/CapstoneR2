using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Apps
{
    [Authorize(Roles = "admin")]
    public class ViewApptModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public ViewApptModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet(Guid? id = null)

        {

            var appts = _context?.Appointments?.Where(a => a.ID == id).ToList();
            View.Appointments = appts;
            
            
        }

           
       
        public class ViewModel
        {
            public List<Appointment>? Appointments { get; set; }
        }
    }
}
