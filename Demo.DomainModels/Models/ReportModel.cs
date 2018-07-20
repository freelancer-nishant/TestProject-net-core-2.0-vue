using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DomainModels.Models
{
    public class ReportModel
    {
        public string Day { get; set; }
        public List<TaskReportModel> Tasks { get; set; }
    }

    public class TaskReportModel
    {
        public string Task { get; set; }
        public List<DepartmentReportModel> Departments { get; set; }
    }

    public class DepartmentReportModel
    {
        public string Department { get; set; }
        public List<EmploymentTypeReportModel> EmploymentTypes { get; set; }
    }

    public class EmploymentTypeReportModel
    {
        public string EmploymentType { get; set; }
        public List<string> Employees { get; set; }
    }
}
