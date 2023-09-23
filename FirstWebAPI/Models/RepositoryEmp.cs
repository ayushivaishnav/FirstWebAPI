using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

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
            EntityState es = _context.Entry(newemployeeData).State;
            Console.WriteLine($"EntityState Before Add : {es.GetDisplayName()}");
            _context.Employees.Add(newemployeeData);
            es = _context.Entry(newemployeeData).State;
            Console.WriteLine($"EntityState After Add : {es.GetDisplayName()}");
            _context.SaveChanges();
            es= _context.Entry(newemployeeData).State;
            Console.WriteLine($"EntityState After Save Changes : {es.GetDisplayName()}");
            
            return newemployeeData;

        }
        public int updateEmployee(Employee modifiedEmployeeData)
        {
            EntityState es =  _context.Entry(modifiedEmployeeData).State;
            Console.WriteLine($"EntityState Before Update :{es.GetDisplayName()}");
            _context.Employees.Update(modifiedEmployeeData);
            es = _context.Entry(modifiedEmployeeData).State;
            Console.WriteLine($"EntityState After Update : {es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(modifiedEmployeeData).State;
            Console.WriteLine($"EntityState After Save Changes : {es.GetDisplayName()}");
            return result;

        }

        public int DeleteEmployee(int id)
        {
            Employee  empToDelete = _context.Employees.Find(id);
            EntityState es = _context.Entry(empToDelete).State;

            int result = 0;
            if(empToDelete != null )
            {
                es=_context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState Before Update :{es.GetDisplayName()}");
                _context.Employees.Remove(empToDelete);
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After Update : {es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After Save Changes : {es.GetDisplayName()}");
            }
            return result;
        }
    }
}
