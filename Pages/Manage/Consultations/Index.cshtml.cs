using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneR2.Pages.Manage.Consultations
{
    [Authorize(Roles = "admin")]
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

        public IActionResult OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Ascending, string? keyword = "")
        {

            var skip = (int)((pageIndex - 1) * pageSize);

            var query = _context.ConsultationRecords.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.Symptoms != null && a.Symptoms.ToLower().Contains(keyword.ToLower())
                      
                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "firstname" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.Symptoms);
                }
              
            }

            var Consultationrecords = query
                            .Skip(skip)
                            .Take((int)pageSize)
                            .ToList();

            View.Consultationrecords = new Paged<ConsultationRecord>()
            {
                Items = Consultationrecords,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRows = totalRows,
                SortBy = sortBy,
                SortOrder = sortOrder,
                Keyword = keyword
            };
            return Page();

        }

        public class ViewModel
        {
            public Paged<ConsultationRecord>? Consultationrecords { get; set; }
        }
    }
}
