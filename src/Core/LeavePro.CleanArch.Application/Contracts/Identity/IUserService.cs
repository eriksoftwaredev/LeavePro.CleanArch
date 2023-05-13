using LeavePro.CleanArch.Application.Models.Identity;

namespace LeavePro.CleanArch.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string employeeId);
}