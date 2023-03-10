using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CapstoneR2.Pages.Manage.Apps
{
    [Authorize(Roles = "admin")]
    public class Appt : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Appt(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public IActionResult OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Ascending, string? keyword = "")
        {

            var skip = (int)((pageIndex - 1) * pageSize);

            var query = _context.Appointments.Include(a => a.Patient).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.Symptom != null && a.Symptom.ToLower().Contains(keyword.ToLower())

                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "symptom" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.Symptom);
                }

            }

            var appointments = query
                            .Skip(skip)
                            .Take((int)pageSize)
                            .ToList();

            View.Appointments = new Paged<Appointment>()
            {
                Items = appointments,
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
            public Paged<Appointment>? Appointments { get; set; }
        }
    }
}
