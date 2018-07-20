using System;
using System.Collections.Generic;
using System.Text;
using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Models;
using System.Threading.Tasks;

namespace Demo.BLL.IService
{
    public interface IEmploymentTypeService
    {
        Task<ApiResponse<List<EmploymentTypeModel>>> GetEmploymentTypeAsync();
    }
}
