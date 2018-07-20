using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Entities;
using Demo.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DAL.Abstract
{
    public interface IEmployeeTaskRepository : IEntityBaseRepository<EmployeeTask, int>
    {
        List<EmployeeTask> GetTasks(int? departmentId, int? employmentTypeId, int? employeeId);
    }
}
