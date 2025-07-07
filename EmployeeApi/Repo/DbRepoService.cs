using EmployeeApi.Models;
using EmployeeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeApi.Repo
{
    public class DbRepoService :IRepoService
    {
        private readonly ApplicationDbContext _DbContext;

        public DbRepoService(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _DbContext.AddAsync(employee);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            employees = await _DbContext.Employees.ToListAsync();

            return employees;
        }
        public async Task<Employee?> GetEmployeeId(int id)
        {
            return await _DbContext.Employees.FindAsync(id);
        }

       
        public async Task DeleteEmployee(Employee employee)
        {
            _DbContext.Employees.Remove(employee);
             await _DbContext.SaveChangesAsync();
        }
        public async Task UpdateEmployee(Employee employee)
        {
            await _DbContext.Employees.FindAsync(employee);
             _DbContext.Update(employee);
            await _DbContext.SaveChangesAsync();
        }

        public Task<Employee?> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
