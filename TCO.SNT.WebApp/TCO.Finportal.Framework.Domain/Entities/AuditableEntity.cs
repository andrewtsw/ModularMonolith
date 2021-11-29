using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Framework.Domain.Entities
{
    public abstract class AuditableEntity
    {
        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime Created { get; set; }
    }
}
