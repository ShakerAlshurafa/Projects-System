using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.Models.user;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CustomersController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var customers = dbContext.Customers
                .Select(customer => new
                {
                    Customer = customer,
                    WorkgroupNames = dbContext.Workgroups
                        .Where(w => w.CustomerId == customer.Id)
                        .Select(w => w.Name)
                        .ToList()
                })
                .ToList();
            var viewModel = customers.Select(c => new CustomersVM
            {
                Id = c.Customer.Id,
                Name = c.Customer.Name,
                Email = c.Customer.Email,
                PhoneNumber = c.Customer.PhoneNumber,
                WorkgroupNames = c.WorkgroupNames
            }).ToList();
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerCreateVM customerCreateVm)
        {
            if (ModelState.IsValid)
            {
                var customer = mapper.Map<Customer>(customerCreateVm);
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(customerCreateVm);
        }
    }
}
