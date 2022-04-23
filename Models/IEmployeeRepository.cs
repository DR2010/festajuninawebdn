using System.Collections;

namespace DanFestaJuninaCore.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable GetAllEmployee();

    }
}
