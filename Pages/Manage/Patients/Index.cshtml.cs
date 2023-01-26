using CapstoneR2.Infrastructure.Domain.Models;
using CapstoneR2.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using CapstoneR2.Infrastructure.Domain.Security;
using Microsoft.AspNetCore.Authorization;

namespace CapstoneR2.Pages.Manage.Patients
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

            var query = _context.Users.Where(a => a.PatientID !=null).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.FirstName != null && a.FirstName.ToLower().Contains(keyword.ToLower())
                        || a.LastName != null && a.LastName.ToLower().Contains(keyword.ToLower())
                        || a.Address != null && a.Address.ToLower().Contains(keyword.ToLower())
                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "firstname" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.FirstName);
                }
                else if (sortBy.ToLower() == "middlename" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.MiddleName);
                }
                else if (sortBy.ToLower() == "lastname" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.LastName);
                }
                else if (sortBy.ToLower() == "lastname" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Address);
                }
                else if (sortBy.ToLower() == "address" && sortOrder == SortOrder.Ascending)
                {
                    query = _context.Users.OrderBy(a => a.Address);
                }
                else if (sortBy.ToLower() == "address" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Address);
                }
            }

            var patients = query
                            .Skip(skip)
                            .Take((int)pageSize)
                            .ToList();

            View.Patients = new Paged<User>()
            {
                Items = patients,
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
            public Paged<User>? Patients { get; set; }
        }
    }
}

