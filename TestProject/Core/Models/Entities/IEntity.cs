using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Core.Models.Entities
{
    public abstract class IEntity
    {
        public IEntity()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
