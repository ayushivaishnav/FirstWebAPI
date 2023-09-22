namespace FirstWebAPI.Models
{
    public class RepositoryEmp
    {
        private NorthwindContext _context;
        public RepositoryEmp(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmp()
        {

            return _context.Employees.ToList();

        }
        public Employee GetEmployeeId(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public Employee UpdateEmployee(Employee updatedEmployeeData)
        {
            _context.Employees.Update(updatedEmployeeData);
            // Save changes to the database
            _context.SaveChanges();
            return updatedEmployeeData;
        }
        public Employee DeleteEmployee(Employee DeletedEmployeeData)
        {
            _context.Employees.Remove(DeletedEmployeeData);
            // Save changes to the database
            _context.SaveChanges();
            return DeletedEmployeeData;
        }
        public Employee AddEmployee(Employee newemployeeData)
        {
            _context.Employees.Add(newemployeeData);
            _context.SaveChanges();
            return newemployeeData;

        }
    }
}
