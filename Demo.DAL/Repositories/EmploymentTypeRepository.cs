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
    public class EmploymentTypeRepository : EntityBaseRepository<EmploymentType, int>, IEmploymentTypeRepository
    {
        private DemoDbContext db;
        public EmploymentTypeRepository(DemoDbContext db) : base(db)
        {
        }
    }
}
