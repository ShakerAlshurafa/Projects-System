using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPCS.Data;
using SPCS.Models;
using SPCS.Models.project;
using SPCS.Models.user;
using SPCS.ViewModel;

namespace SPCS.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);
            var projects = context.Projects
                .Where(p => p.ProjectUsers.Any(pu => pu.UserId == userId))
                .ToList();
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
                .Select(p => new
                {
                    data = p,
                    team = p.Workgroup != null && p.Workgroup.Team != null ? new { p.Workgroup.Team.Students, p.Workgroup.Team.Supervisors } : null,
                    customer = p.Workgroup != null ? p.Workgroup.Customer : null
                })
                .FirstOrDefault(p => p.data.Id == id);

                //// Another way can we use insted of select
                ///
                ///  I prefere Select than include because i want to include what i want from Customer, Student, Supervisor
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Customer)
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Team)
                //        .ThenInclude(t => t.Students)
                //.Include(p => p.Workgroup)
                //    .ThenInclude(w => w.Team)
                //        .ThenInclude(t => t.Supervisors)

            if (project == null)
            {
                return NotFound();
            }

            project.data.Workgroup = new Workgroup
            {
                Team = new Team()
            };

            
            project.data.Workgroup.Team.Students = project.team?.Students ?? new List<Student>();
            project.data.Workgroup.Team.Supervisors = project.team?.Supervisors ?? new List<Supervisor>();
            project.data.Workgroup.Customer = project.customer ?? new Customer();
            
            var viewModel = mapper.Map<ProjectDetailsVM>(project.data);
            return View(viewModel);

            //// Try to get data direct from user table so we can do without Studetn, Customer, Supervisor tables
            ///  Not complete yet
            ///  
            //var students = userManager.Users
            //    .Select(p => new {
            //        data = p,
            //        roles = p.ProjectUsers.Select(p => p.Role).FirstOrDefault(),
            //    })
            //    .Where(p => p.data.ProjectUsers.Any(u => u.ProjectId == id && u.Role == "Student"))
            //    .ToList();
            //var studentsVM = new List<ApplicationUser>();
            //foreach(var st in students)
            //{
            //    var tempStudent = new ApplicationUser
            //    {
            //        Id = st.data.Id,
            //        UserName = st.data.UserName
            //    };
            //    studentsVM.Add(tempStudent);
            //}
            //project.data.ProjectStudnet = studentsVM;

        }

    }
}
