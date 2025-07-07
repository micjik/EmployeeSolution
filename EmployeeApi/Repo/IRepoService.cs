using EmployeeApi.Models;

namespace EmployeeApi.Repo
{
    public interface IRepoService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeById(int id);
        Task CreateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
 
        Task UpdateEmployee(Employee employee);

    }
}
