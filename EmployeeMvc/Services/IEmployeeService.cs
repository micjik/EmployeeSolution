using EmployeeMvc.Models;

namespace EmployeeMvc.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeGetDtos>> GetAll();
        Task<bool> CreateEmployee(EmployeeCreateDtos employee);
        Task<EmployeeGetDtos?> GetEmployeeById(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateAsync(int id, EmployeeCreateDtos employee);
    }
}
