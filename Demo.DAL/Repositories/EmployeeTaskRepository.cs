using Demo.DAL.Abstract;
using Demo.DomainModels.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Demo.DomainModels.Exceptions;

namespace Demo.DAL.Repositories
{
    public class EmployeeTaskRepository : EntityBaseRepository<EmployeeTask, int>, IEmployeeTaskRepository
    {
        private DemoDbContext db;
        public EmployeeTaskRepository(DemoDbContext db) : base(db)
        {
        }

        public List<EmployeeTask> GetTasks(int? departmentId, int? employmentTypeId, int? employeeId)
        {
            var q = this.entities
                .Include(x => x.Employee).ThenInclude(x => x.Department)
                .Include(x => x.Employee).ThenInclude(x => x.EmploymentType)
                .Include(x => x.Task).AsQueryable();

            if (departmentId.HasValue)
            {
                q = q.Where(x => x.Employee.DepartmentId == departmentId);
            }
            if (employmentTypeId.HasValue)
            {
                q = q.Where(x => x.Employee.EmploymentTypeId == employmentTypeId);
            }
            if (employeeId.HasValue)
            {
                q = q.Where(x => x.Employee.Id == employeeId);
            }

            return q.ToList();
        }
    }
}
