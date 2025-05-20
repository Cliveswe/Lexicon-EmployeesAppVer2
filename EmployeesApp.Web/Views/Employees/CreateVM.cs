using EmployeesApp.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Web.Views.Employees
{
    public class CreateVM
    {
        [Required(ErrorMessage = "You must specify a name")]
        public string Name { get; set; } = null!;
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        [Required(ErrorMessage = "You must specify an e-mail address")]
        public string Email { get; set; } = null!;
        [Display(Name = "What is 2+2?")]
        [Range(4,4, ErrorMessage = "Invalid answer")]
        [Required(ErrorMessage = "You must answer the validation question")]
        public int BotCheck { get; set; }
    }
}
