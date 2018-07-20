using System;
using System.Collections.Generic;
using System.Text;
using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Models;
using System.Threading.Tasks;

namespace Demo.BLL.IService
{
    public interface IEmployeeService
    {
        Task<ApiResponse<List<EmployeeModel>>> GetEmployeesAsync();
        Task<ApiResponse<EmployeeModel>> GetEmployeeByIdAsync(int id);
        Task<ApiResponse<bool>> AddEmployeeAsync(EmployeeModel model);
    }
}
