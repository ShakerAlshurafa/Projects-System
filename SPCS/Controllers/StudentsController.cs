using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPCS.Data;
using SPCS.Models;
using SPCS.Models.user;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public StudentsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
		public IActionResult Index()
		{
			var studentsWithWorkgroups = dbContext.Students
				.Select(student => new
				{
					Student = student,
					WorkgroupNames = dbContext.Workgroups
						.Where(w => w.TeamId == student.TeamId)
						.Select(w => w.Name)
						.ToList()
				})
				.ToList();

			var viewModel = studentsWithWorkgroups.Select(s => new StudentVM
			{
				Id = s.Student.Id,
				FirstName = s.Student.FirstName,
				MiddleName = s.Student.MiddleName,
				LastName = s.Student.LastName,
				Email = s.Student.Email,
				WorkgroupNames = s.WorkgroupNames
			}).ToList();

			return View(viewModel);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			var teams = dbContext.Teams.ToList();
			ViewBag.Teams = teams;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(StudentCreateVM studentCreateVm)
		{
			if (ModelState.IsValid)
			{
				var student = mapper.Map<Student>(studentCreateVm);
				dbContext.Students.Add(student);
				dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}

			return View(studentCreateVm);
		}

	}
}
