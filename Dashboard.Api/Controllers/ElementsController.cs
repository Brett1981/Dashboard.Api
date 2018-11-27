using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Common;
using Api.Common.Repository;
using Dashboard.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IDashboardRepositoryContext _context;

        public ElementsController(IDashboardRepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DashboardElement>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DashboardElement>>> GetAllElementsAsync()
        {
            var definitions =  await _context.Definitions.GetAsync();
            return definitions.Select(d => d.ToElement()).ToList();
        }

        [HttpGet("{id}", Name = "GetElement")]
        [ProducesResponseType(typeof(DashboardElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardElement>> GetElementAsync(int id)
        {
            var definition = await _context.Definitions.GetAsync(id);
            if (definition == null)
            {
                return NotFound();
            }

            return definition.ToElement();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DashboardElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardElement>> UpdateListElementAsync(int id, [FromBody] DashboardElement element)
        {
            var current = await _context.Definitions.GetAsync(id);
            if (current == null)
            {
                return NotFound();
            }
     
            var definitions = await _context.Definitions.GetAsync();
            PositionAdjuster.AdjustForUpdate(element, definitions.ToList<ISortable>(), current);

            current.UpdateFrom(element);

            _context.Definitions.Update(current);
            await _context.SaveChangesAsync();

            return current.ToElement();
        }
    }
}
