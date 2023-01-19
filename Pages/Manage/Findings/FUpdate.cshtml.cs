using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Findings
{
    [Authorize(Roles = "admin")]
    public class FUpdate : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public FUpdate(DefaultDBContext context, ILogger<Index> logger)
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

            var finding = _context?.Findings?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       ID = a.ID,
                                       Tags = a.Tags,
                                       Description = a.Description,
                                       


                                   }).FirstOrDefault();



            View = finding;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.Tags))
            {
                ModelState.AddModelError("", "Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.Description))
            {
                ModelState.AddModelError("", "Description cannot be blank.");
                return Page();
            }




            var existingFindings = _context?.Findings?.FirstOrDefault(a =>
                    a.ID != View.ID &&
                    a.Tags.ToLower() == View.Tags.ToLower()&&
                    a.Description.ToLower() == View.Description.ToLower()





            );

            if (existingFindings != null)
            {
                ModelState.AddModelError("", "Role is already existing.");
                return Page();
            }

            var finding = _context?.Findings?.FirstOrDefault(a => a.ID == View.ID);

            if (finding != null)
            {
                finding.Tags = View.Tags;
                finding.Description = View.Description;
               


                _context?.Findings?.Update(finding);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/Findings");
            }

            return Page();

        }

        public class ViewModel : Finding
        {

        }
    }
}
