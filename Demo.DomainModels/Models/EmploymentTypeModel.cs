using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.DomainModels.Models
{
    public class EmploymentTypeModel
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Type { get; set; }
    }
}
