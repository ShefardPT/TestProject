using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Core.Models.DTOs;
using TestProject.Core.Models.Entities;
using TestProject.Infrastructure;

namespace TestProject.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private ApplicationDbContext _ctx;

        public TestController
            (ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet()]
        public IActionResult GetTestEntities()
        {
            var result = _ctx.TestEntities
                .OrderByDescending(x => x.DateCreated)
                .Select(x => new TestEntityDTO(x));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestEntityById
            ([FromRoute]Guid id)
        {
            var entity = _ctx.TestEntities.FirstOrDefault(x => x.Id.Equals(id));

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(new TestEntityDTO(entity));
        }

        [HttpPost("form")]
        public async Task<IActionResult> AddTestEntityByFormAsync
            ([FromForm] TestEntityDTOToCreate data)
        {
            var utcTime = data.Date.ToUniversalTime();

            var result = await AddTestEntityAsync(new TestEntity(data));

            return Ok(new TestEntityDTO(result));
        }

        [HttpPost("body")]
        public async Task<IActionResult> AddTestEntityByBodyAsync
            ([FromBody] TestEntityDTOToCreate data)
        {
            var result = await AddTestEntityAsync(new TestEntity(data));

            return Ok(new TestEntityDTO(result));
        }

        private async Task<TestEntity> AddTestEntityAsync
            (TestEntity entity)
        {
            await _ctx.TestEntities.AddAsync(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }
    }
}
