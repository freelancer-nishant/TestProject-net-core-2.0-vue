using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.DomainModels.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNo { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public int EmploymentTypeId { get; set; }

        [StringLength(120)]
        public string EmploymentType { get; set; }

        public int DepartmentId { get; set; }

        [StringLength(120)]
        public string DepartmentName { get; set; }
    }
}
