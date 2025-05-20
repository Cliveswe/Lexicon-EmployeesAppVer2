using EmployeesApp.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Web.Views.Employees
{
    public class IndexVM
    {
        public required EmployeeItemVM[] employeeList { get; set; }
        public class EmployeeItemVM
        {
            public required int Id { get; set; }

            [Required(ErrorMessage = "You must specify a name")]
            [SuspiciousPerson("Pontus Wittenmark", ErrorMessage = "Suspicious person detected!")]
            public required string Name { get; set; }

            [Display(Name = "E-mail")]
            [EmailAddress(ErrorMessage = "Invalid e-mail address")]
            [Required(ErrorMessage = "You must specify an e-mail address")]
            public required string Email { get; set; }
            public required bool ShowAsHighlighted { get; set; }
        }
        
    }
}
