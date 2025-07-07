using EmployeeApi.Dtos;

namespace EmployeeApi.Service
{
    public interface IServiceEmployee
    {
        Task<List<EmployeeGetDtos>> GetEmployeesAsync();
        Task<string> CreateEmployee(EmployeeCreateDtos employee);
        Task<EmployeeGetDtos?> GetEmployeeById(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateAsync(int id, EmployeeCreateDtos employee);
        
       
        
    }
}
