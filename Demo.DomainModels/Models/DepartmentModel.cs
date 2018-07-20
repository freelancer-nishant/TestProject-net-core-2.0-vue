using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.DomainModels.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Name { get; set; }
    }
}
