using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Entities;
using Demo.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Abstract
{
    public interface IDepartmentRepository : IEntityBaseRepository<Department, int>
    {
    }
}
