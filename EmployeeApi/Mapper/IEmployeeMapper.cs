using EmployeeApi.Dtos;
using EmployeeApi.Models;

namespace EmployeeApi.Mapper
{
    public interface IEmployeeMapper
    {
        Employee EmployeeCreateDtosToEmployee(EmployeeCreateDtos employeeCreateDtos);
        EmployeeGetDtos EmployeeToEmployeeGetDtos(Employee employee);
        List<EmployeeGetDtos> EmployeeListToEmployeeGetDtoslist(List<Employee> employees);
    }
}
