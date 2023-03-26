using System.Collections.Generic;
using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class EmployeStudentListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<Student>  Students { get; set; }
    }
}
