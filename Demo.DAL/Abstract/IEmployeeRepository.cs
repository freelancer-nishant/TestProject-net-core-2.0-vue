using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Entities;
using Demo.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Abstract
{
    public interface IEmployeeRepository : IEntityBaseRepository<Employee, int>
    {
        List<Employee> GetEmployeesAsync();
        Employee GetEmployeeByIdAsync(int id);
    }
}
