using CapstoneR2.Infrastructure.Domain.Models.Enums;
using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Prescriptions
{
    [Authorize(Roles = "admin")]
    public class PUpdate : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PUpdate(DefaultDBContext context, ILogger<Index> logger)
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

            var precription = _context?.Prescriptions?.Where(a => a.ID == id)
                                   .Select(a => new ViewModel()
                                   {
                                       ID = a.ID,
                                       Tags = a.Tags,
                                       Description = a.Description,
                                      
                                   }).FirstOrDefault();

            if (precription == null)
            {
                return NotFound();
            }

            View = precription;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(View.Tags))
            {
                ModelState.AddModelError("", " Tags cannot be blank.");
                return Page();
            }
            if (string.IsNullOrEmpty(View.Description))
            {
                ModelState.AddModelError("", "Description cannot be blank.");
                return Page();
            }
          

           
           
          
          

            var existingPrescription = _context?.Prescriptions?.FirstOrDefault(a =>
                    a.ID != View.ID &&
                    a.Tags.ToLower() == View.Tags.ToLower() &&
                    a.Description.ToLower() == View.Description.ToLower() 
                  




            );

            if (existingPrescription != null)
            {
                ModelState.AddModelError("", "Role is already existing.");
                return Page();
            }

            var prescription = _context?.Prescriptions?.FirstOrDefault(a => a.ID == View.ID);

            if (prescription != null)
            {
                prescription.Tags = View.Tags;
                prescription.Description = View.Description;
                

                _context?.Prescriptions?.Update(prescription);
                _context?.SaveChanges();

                return RedirectPermanent("~/manage/patients");
            }

            return Page();

        }

        public class ViewModel : Prescription
        {

        }
    }
}
