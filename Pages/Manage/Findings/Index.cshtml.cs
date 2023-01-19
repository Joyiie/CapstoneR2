using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneR2.Pages.Manage.Findings
{
    public class Index : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Index(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet()
        {
            View.Findings = _context.Findings.ToList();
        }

        public class ViewModel
        {
            public List<Finding>? Findings { get; set; }
        }
    }

}
