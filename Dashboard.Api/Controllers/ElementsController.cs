using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Common;
using Api.Common.Repository;
using Dashboard.Api.Models;
using Dashboard.Api.Services;
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

        [HttpGet("folders")]
        [ProducesResponseType(typeof(IEnumerable<FolderElement>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FolderElement>>> GetAllFolderElementsAsync()
        {
            var folders =  await _context.Folders.GetAsync(f => f.Definitions);

            // sort definitions to get correct default definition
            folders.ForEach(d => d.Definitions = d.Definitions.OrderBy(t => t.Position).ToList());

            return folders.Select(d => d.ToElement()).ToList();
        }

        [HttpGet("folders/{id}")]
        [ProducesResponseType(typeof(FolderElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<FolderElement>> GetFolderElementAsync(int id)
        {
            var folder = await FetchFolderAsync(id);
            if (folder == null)
            {
                return NotFound();
            }
            else
            {
                return folder.ToElement();
            }
        }

        private async Task<DashboardFolder> FetchFolderAsync(int id)
        {
            DashboardFolder list = await _context.Folders.GetAsync(id, f => f.Definitions);
            if (list != null)
            {
                list.Definitions = list.Definitions.OrderBy(o => o.Position).ToList();
            }

            return list;
        }

        [HttpGet("definitions/{id}")]
        [ProducesResponseType(typeof(DefinitionElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DefinitionElement>> GetDefinitionElementAsync(int id)
        {
            var definition = await _context.Definitions.GetAsync(id);
            if (definition == null)
            {
                return NotFound();
            }
            else
            {
                return definition.ToElement();
            }
        }

        [HttpGet("folders/{id}/definitions")]
        [ProducesResponseType(typeof(IEnumerable<DefinitionElement>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<DefinitionElement>>> GetAllDefinitionElementsAsync(int id)
        {
            var folder = await FetchFolderAsync(id);
            if (folder == null)
            {
                return NotFound();
            }
            else
            {
                return folder.Definitions;
            }
        }

        [HttpPut("definitions/{id}")]
        [ProducesResponseType(typeof(DefinitionElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DefinitionElement>> UpdateDefinitionElementAsync(int id, [FromBody] DefinitionElement element)
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

        [HttpPut("folders/{id}")]
        [ProducesResponseType(typeof(FolderElement), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<FolderElement>> UpdateFolderElementAsync(int id, [FromBody] FolderElement element)
        {
            var current = await FetchFolderAsync(id);
            if (current == null)
            {
                return NotFound();
            }

            var folders = await _context.Folders.GetAsync();
            PositionAdjuster.AdjustForUpdate(element, folders.ToList<ISortable>(), current);

            current.UpdateFrom(element);

            _context.Folders.Update(current);
            await _context.SaveChangesAsync();

            return current.ToElement();
        }
    }
}
