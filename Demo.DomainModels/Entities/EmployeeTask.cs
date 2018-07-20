﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DomainModels.Entities
{
    public class EmployeeTask : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int TaskId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Task Task { get; set; }

    }
}
