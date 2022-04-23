using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace DanFestaJuninaCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@gmail.com"},
                new Employee() { Id = 2, Name = "John", Department = "HR", Email = "john@gmail.com"},
                new Employee() { Id = 3, Name = "Sam", Department = "HR", Email = "sam@gmail.com"}
            };
        }
        public Employee GetEmployee(int Id)
        {

            Employee _employee = new Employee();
            _employee = _employeeList.FirstOrDefault(e => e.Id == Id);

            return _employee;
        }

        IEnumerable IEmployeeRepository.GetAllEmployee()
        {
            return _employeeList;
        }
    }
}
