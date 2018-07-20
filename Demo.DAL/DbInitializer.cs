using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.DAL
{
    public static class DbInitializer
    {
        public static void Seed(DemoDbContext dBContext)
        {
            if(!dBContext.Departments.Any())
            {
                dBContext.Departments.Add(new DomainModels.Entities.Department() { Name = "IT" });
                dBContext.Departments.Add(new DomainModels.Entities.Department() { Name = "Accounting" });
                dBContext.Departments.Add(new DomainModels.Entities.Department() { Name = "HR" });
                dBContext.Departments.Add(new DomainModels.Entities.Department() { Name = "Admin" });
            }

            if (!dBContext.EmploymentTypes.Any())
            {
                dBContext.EmploymentTypes.Add(new DomainModels.Entities.EmploymentType() { Type = "Full-Time" });
                dBContext.EmploymentTypes.Add(new DomainModels.Entities.EmploymentType() { Type = "Part-Time" });
                dBContext.EmploymentTypes.Add(new DomainModels.Entities.EmploymentType() { Type = "Contractor" });
            }

            dBContext.SaveChanges();
        }
    }
}
