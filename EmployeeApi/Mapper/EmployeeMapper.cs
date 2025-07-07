using EmployeeApi.Dtos;
using EmployeeApi.Models;
using EmployeeApi.Data;

namespace EmployeeApi.Mapper
{
    public class EmployeeMapper : IEmployeeMapper

    {
        public Employee EmployeeCreateDtosToEmployee(EmployeeCreateDtos employeeCreateDtos)
        {
            Employee employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.Name = employeeCreateDtos.Name;
            return employee;
        }

        public List<EmployeeGetDtos> EmployeeListToEmployeeGetDtoslist(List<Employee> employeeList)
        {
           List<EmployeeGetDtos> employeeGetDtosList = new List<EmployeeGetDtos>();
            foreach(var  employee in employeeList)
            {
                EmployeeGetDtos employeeGetDtos = new EmployeeGetDtos();
                employeeGetDtos.Name = employee.Name;
                employee.CreatedDate = employee.CreatedDate;
                
                employeeGetDtosList.Add(employeeGetDtos);

            }
            return employeeGetDtosList;
        }

        public EmployeeGetDtos EmployeeToEmployeeGetDtos(Employee employee)
        {
            EmployeeGetDtos employeeGetDtos = new EmployeeGetDtos();
            employeeGetDtos.Name = employee.Name;
            employeeGetDtos.CreatedDate = employee.CreatedDate;
            return employeeGetDtos;

        }
    }
}
