using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Account
{
    [Authorize(Roles = "admin")]
    public class Users : PageModel
    {
        private ILogger<Users> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Users(DefaultDBContext context, ILogger<Users> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet()
        {
            View.Users = _context.Users.ToList();
        }

        public class ViewModel
        {
            public List<User>? Users { get; set; }
        }
    }

}
