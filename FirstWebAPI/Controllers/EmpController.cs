using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private RepositoryEmp _repositoryEmployee;
        public EmpController(RepositoryEmp repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        // GET: EmployeeController
        public IEnumerable<EmpViewModel> GetallEmp()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
                ).ToList();
            return empList;
        }

        [HttpGet("/GetEmp")]
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            return employees;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        [HttpPut]
        public Employee Put(int id, [FromBody] Employee updatedEmployeeData)
        {
            updatedEmployeeData.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployeeData);
            return savedEmployee;

        }
        [HttpDelete]
        public Employee Delete(int id, [FromBody] Employee DeletedEmployeeData)
        {
            DeletedEmployeeData.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.DeleteEmployee(DeletedEmployeeData);
            return savedEmployee;

        }

        [HttpPost("/AddEmp")]
        public IActionResult AddEmployee([FromBody] EmpViewModel employeeRequest)

        {
            if (employeeRequest == null)
            {
                return BadRequest("Employee data is missing in the request.");
            }
            Employee newEmployee = new Employee
            {
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                BirthDate = employeeRequest.BirthDate,
                HireDate = employeeRequest.HireDate,
                Title = employeeRequest.Title,
                City = employeeRequest.City,
                ReportsTo = employeeRequest.ReportsTo > 0 ? employeeRequest.ReportsTo : null
            };
            Employee addedEmployee = _repositoryEmployee.AddEmployee(newEmployee);
            // Return a Created response with the newly created employee

            return CreatedAtAction(nameof(EmployeeDetails), new { id = addedEmployee.EmployeeId }, addedEmployee);

        }


    }

}

