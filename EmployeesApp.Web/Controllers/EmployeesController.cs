using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Web.Views.Employees;

namespace EmployeesApp.Web.Controllers
{
    public class EmployeesController : Controller
    {
        static EmployeeService service = new EmployeeService();

        [HttpGet("")]
        public IActionResult Index()
        {
            var model = service.GetAll();
            var viewModel = new IndexVM
            {
                employeeList = model
                .Select(o => new IndexVM.EmployeeItemVM
                {
                    Name = o.Name,
                    Id = o.Id,
                    Email = o.Email,
                    ShowAsHighlighted = service.ShowAsHighLighted(o.Email)

                })
                .ToArray()
            };
            return View(viewModel);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(CreateVM createVM)
        {
            if (!ModelState.IsValid || createVM.BotCheck != 4)
                return View();

            Employee employee = new Employee
            {
                Name = createVM.Name,
                Email = createVM.Email
            };
            service.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var model = service.GetById(id);
            return View(model);
        }
    }
}
