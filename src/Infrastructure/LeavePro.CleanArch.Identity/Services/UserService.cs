using LeavePro.CleanArch.Application.Contracts.Identity;
using LeavePro.CleanArch.Application.Models.Identity;
using LeavePro.CleanArch.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LeavePro.CleanArch.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");

        return employees.Select(q => new Employee
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName,
        }).ToList();
    }

    public async Task<Employee> GetEmployee(string employeeId)
    {
        var employee = await _userManager.FindByIdAsync(employeeId);

        return new Employee()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email
        };
    }
}