using Entity_FrameWork_1.Data;
using Entity_FrameWork_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_FrameWork_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }


        [HttpPost("add")]
        public ActionResult Add(Employee employee)
        {
            var x = _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return Ok("success");

        }
        [HttpGet]

        public ActionResult GetEmployees()
        {
            var c = _employeeContext.Employees;

            return Ok(c);
        }

        [HttpDelete]

        public ActionResult DeleteEmployee(int Id)
        {
            var w = _employeeContext.Employees.FirstOrDefault(n=> n.Id== Id);
            _employeeContext.Employees.Remove(w);
            _employeeContext.SaveChanges();
            return Ok("success");


        }

        [HttpPatch]

        public ActionResult UpdateEmployee(int Id,Employee employee)

        {

            var q = _employeeContext.Employees.FirstOrDefault(n => n.Id == Id);

            q.Name = employee.Name;
            _employeeContext.SaveChanges();
            return Ok("success");

        }

        [HttpGet("id")]

        public ActionResult GetEmployeeById(int Id)
        {
            var s = _employeeContext.Employees.FirstOrDefault(n => n.Id == Id);

            return Ok(s);
        }

    }
}
