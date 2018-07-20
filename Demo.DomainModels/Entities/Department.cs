using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DomainModels.Entities
{
    public class Department : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
