using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.Domain.Security;
using CapstoneR2.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CapstoneR2.Pages.Dashboard
{
    [Authorize(Roles = "patient")]
    public class PatientModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;
        [BindProperty]
        public ViewModel View { get; set; }




        public PatientModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public IActionResult OnGet()
        {
            Guid? userId = User.Id();
            var user = _context?.Users?.Where(a => a.ID == userId)
                .Select(a => new ViewModel()
                {
                    
                    Address= a.Address,
                    BirthDate= a.BirthDate,
                    Email= a.Email,
                    FirstName= a.FirstName,
                    Gender= a.Gender,
                    LastName    = a.LastName,
                    MiddleName= a.MiddleName,
                }).FirstOrDefault();

            ViewData["address"]         = user.Address;
            ViewData["birthdate"]       = user.BirthDate;
            ViewData["email"]           = user.Email;
            ViewData["firstname"]       = user.FirstName;
            ViewData["middlename"]      = user.MiddleName;
            ViewData["lastname"]        = user.LastName;
            ViewData["gender"]          = user.Gender;

            View = user;
            return Page();
        }


        public class ViewModel : UserViewModel
        {

        }
    }
}
