using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Core.Models.Entities;

namespace TestProject.Core.Models.DTOs
{
    public class TestEntityDTO
    {
        public TestEntityDTO()
        {
            
        }

        public TestEntityDTO(TestEntity entity)
        {
            Id = entity.Id;
            Date = entity.Date;
            DateCreated = entity.DateCreated;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
