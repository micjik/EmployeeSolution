using EmployeeApi.Dtos;
using EmployeeApi.Mapper;
using EmployeeApi.Models;
using EmployeeApi.Repo;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace EmployeeApi.Service
{
    public class ServiceEmployee : IServiceEmployee

    {
        private readonly IRepoService _repoService;
        private readonly IEmployeeMapper _employeeMapper;

        public ServiceEmployee(IRepoService repoService, IEmployeeMapper employeeMapper)
        {
            _repoService = repoService;
            _employeeMapper = employeeMapper;
        }
        public async Task<string> CreateEmployee(EmployeeCreateDtos employeeCreateDtos)
        {
            Employee employee = _employeeMapper.EmployeeCreateDtosToEmployee(employeeCreateDtos);
            employee.SimplifiedName = CreateSimplifiedName(employee.Name);
            await _repoService.CreateEmployee(employee);
            return "successful";
        }

      

        public async Task<List<EmployeeGetDtos>> GetEmployeesAsync()
        {
            List<Employee> employee = await _repoService.GetEmployeesAsync();
            List<EmployeeGetDtos> employeeGetDtos = _employeeMapper.EmployeeListToEmployeeGetDtoslist(employee);
            return employeeGetDtos;
        }

       public async Task<EmployeeGetDtos?> GetEmployeeById(int id)
        {
           var employee = await _repoService.GetEmployeeById(id);
            if(employee == null)
            {
                return null;
            }
            return _employeeMapper.EmployeeToEmployeeGetDtos(employee);

          //  return employee == null ? null : _employeeMapper.EmployeeToEmployeeGetDtos(employee);

            
            
             
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _repoService.GetEmployeeById(id);
            if (employee == null)
            {return false;

            }
            await _repoService.DeleteEmployee(employee);
            return true;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeCreateDtos employee)
        {
            var existing = await _repoService.GetEmployeeById(id);
            if(existing == null)
            {
                return false;
            }
            existing.Name = employee.Name;
            existing.CreatedDate = DateTime.Now;
            await _repoService.UpdateEmployee(existing);
            return true;
        }




        private static string CreateSimplifiedName(string name)
        {
            string shortName = name.Substring(0, 4);
            return shortName;
        }

        public Task<List<EmployeeGetDtos>> GetDtosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeGetDtos?> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
