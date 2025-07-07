namespace EmployeeApi.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? SimplifiedName { get; set; }
    }
}
