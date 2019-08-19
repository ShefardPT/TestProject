using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Core.Models.DTOs;

namespace TestProject.Core.Models.Entities
{
    public class TestEntity : IEntity
    {
        public TestEntity() : base()
        {
            
        }

        public TestEntity
            (TestEntityDTOToCreate data) : base()
        {
            this.Date = data.Date;
        }

        public DateTime Date { get; set; }
    }
}
