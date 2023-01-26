using CapstoneR2.Infrastructure.Domain;
using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain.Models.Enums;
using CapstoneR2.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Account
{

    public class NewUser : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public NewUser(DefaultDBContext context, ILogger<Index> logger)
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
            if (string.IsNullOrEmpty(View.FirstName))
            {
                ModelState.AddModelError("", "First name cannot be blank.");
                return Page();
            }

            if (string.IsNullOrEmpty(View.MiddleName))
            {
                ModelState.AddModelError("", "Middle name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.LastName))
            {
                ModelState.AddModelError("", "Last name cannot be blank.");
                return Page();
            }
            if (!Enum.IsDefined(typeof(Gender), View.Gender))
            {
                ModelState.AddModelError("", "Sex name cannot be blank.");
                return Page();
            }
            if (DateTime.MinValue >= View.BirthDate)
            {
                ModelState.AddModelError("", "Birthdate name cannot be blank.");
                return Page();
            }

            if (string.IsNullOrEmpty(View.Address))
            {
                ModelState.AddModelError("", "Address name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.Email))
            {
                ModelState.AddModelError("", "Address name cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.Password))
            {
                ModelState.AddModelError("", "Address name cannot be blank.");
                return Page();
            }
            
            Guid userGuid = Guid.NewGuid();
            User user = new User()
            {
                ID = userGuid,
                FirstName = View.FirstName,
                MiddleName = View.MiddleName,
                LastName = View.LastName,
                Gender = View.Gender,
                BirthDate = View.BirthDate,
                Address = View.Address,
                Email = View.Email,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101")
            };
            List<UserLogin> userLogins = new List<UserLogin>();
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =userGuid,
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword(View.Password)
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =userGuid,
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =userGuid,
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
          
            UserRole userRole = new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = userGuid,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101")

            };


            _context?.Users?.Add(user);
            _context?.UserLogins?.AddRange(userLogins);
            _context?.UserRoles?.Add(userRole);
            _context?.SaveChanges();

            return RedirectPermanent("~/index");
        }

        public class ViewModel : UserViewModel
        {

        }
    }
}
