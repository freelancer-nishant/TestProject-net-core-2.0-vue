using Demo.DAL.Abstract;
using Demo.DomainModels.ApiResponse;
using Demo.DomainModels.Entities;
using Demo.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Demo.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Demo.DomainModels.Exceptions;

namespace Demo.DAL.Repositories
{
    public class EmployeeRepository : EntityBaseRepository<Employee, int>, IEmployeeRepository
    {
        private DemoDbContext db;
        public EmployeeRepository(DemoDbContext db) : base(db)
        {
        }

        public Employee GetEmployeeByIdAsync(int id)
        {
            var employee = this.entities.Include(x => x.Department).Include(x => x.EmploymentType).FirstOrDefault(x => x.Id == id);
            if (employee == null)
                throw new FailException("Employee does not exists!");

            return employee;
        }

        public List<Employee> GetEmployeesAsync()
        {
            return this.entities.Include(x => x.Department).Include(x => x.EmploymentType).ToList();
        }
    }
}
