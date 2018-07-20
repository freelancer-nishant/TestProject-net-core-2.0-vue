using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DomainModels.Entities
{
    public class Employee : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public int DepartmentId { get; set; }

        public virtual EmploymentType EmploymentType { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }

    }
}
