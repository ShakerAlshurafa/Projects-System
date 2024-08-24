using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPCS.Data;
using SPCS.Models;
using SPCS.Models.project;
using SPCS.Models.user;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProjectsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var projects = context.Projects.ToList();
            var viewModel = mapper.Map<List<ProjectVM>>(projects);
            return View(viewModel);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var project = context.Projects
                .Include(p => p.Goals)
                .Include(p => p.Features)
                .Include(p => p.Audience)
                .Include(p => p.Technology)
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Customer)
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Team)
                //        .ThenInclude(t => t.Students)
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Team)
                //        .ThenInclude(t => t.Supervisors)
                .Select(p => new {
                    data = p,
                    team = p.Workgroup != null && p.Workgroup.Team != null ? new { p.Workgroup.Team.Students, p.Workgroup.Team.Supervisors } : null,
                    customer = p.Workgroup != null ? p.Workgroup.Customer : null
                })
                .FirstOrDefault(p => p.data.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            project.data.Workgroup = new Workgroup();
            project.data.Workgroup.Team = new Team();
            project.data.Workgroup.Team.Students = project.team?.Students ?? new List<Student>();
            project.data.Workgroup.Team.Supervisors = project.team?.Supervisors ?? new List<Supervisor>();
            project.data.Workgroup.Customer = project.customer ?? new Customer();

            var viewModel = mapper.Map<ProjectDetailsVM>(project.data);
            return View(viewModel);

        }
    }
}
