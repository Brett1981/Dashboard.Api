using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Common;
using Api.Common.Repository;
using Dashboard.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionsController : ControllerBase
    {
        private readonly IDashboardRepositoryContext _context;

        public DefinitionsController(IDashboardRepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DashboardDefinition>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DashboardDefinition>>> GetAllDefinitionsAsync()
        {
            return await _context.Definitions.GetAsync(d => d.Tiles);
        }

        [HttpGet("{id}", Name = "GetDefinition")]
        [ProducesResponseType(typeof(DashboardDefinition), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardDefinition>> GetDefinitionAsync(int id)
        {
            var definition = await _context.Definitions.GetAsync(id, d => d.Tiles);
            if (definition == null)
            {
                return NotFound();
            }

            return definition;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DashboardDefinition), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<DashboardDefinition>> CreateDefinitionAsync([FromBody] DashboardDefinition definition)
        {
            var definitions = await _context.Definitions.GetAsync();
            PositionAdjuster.AdjustForCreate(definition, definitions.ToList<ISortable>());

            await _context.Definitions.AddAsync(definition);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetDefinition", new { id = definition.Id }, definition);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DashboardDefinition), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardDefinition>> UpdateDefinitionAsync(int id, [FromBody] DashboardDefinition definition)
        {
            var current = await _context.Definitions.GetAsync(id, d => d.Tiles);
            if (current == null)
            {
                return NotFound();
            }

            var definitions = await _context.Definitions.GetAsync();
            PositionAdjuster.AdjustForUpdate(definition, definitions.ToList<ISortable>(), current);

            current.UpdateFrom(definition);
            _context.Definitions.Update(current);
            await _context.SaveChangesAsync();

            return current;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> DeleteDefinitionAsync(int id)
        {
            var definition = await _context.Definitions.GetAsync(id);
            if (definition == null)
            {
                return NotFound();
            }
            else
            {
                var lists = await _context.Definitions.GetAsync();
                PositionAdjuster.AdjustForDelete(definition, lists.ToList<ISortable>());

                _context.Definitions.Delete(definition);
                await _context.SaveChangesAsync();

                return id;
            }
        }
    }
}
