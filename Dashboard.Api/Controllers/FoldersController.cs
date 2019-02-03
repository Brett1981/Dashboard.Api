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
    public class FoldersController : ControllerBase
    {
        private readonly IDashboardRepositoryContext _context;

        public FoldersController(IDashboardRepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DashboardFolder>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DashboardFolder>>> GetAllFoldersAsync()
        {
            var folders = await _context.Folders.GetAsync(f => f.Definitions);

            // sort definitions by position
            folders.ForEach(d => d.Definitions = d.Definitions.OrderBy(t => t.Position).ToList());

            return folders;
        }

        [HttpGet("{id}", Name = "GetFolder")]
        [ProducesResponseType(typeof(DashboardFolder), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardFolder>> GetFolderAsync(int id)
        {
            var folder = await FetchFolderAsync(id);
            if (folder == null)
            {
                return NotFound();
            }

            return folder;
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

        [HttpPost]
        [ProducesResponseType(typeof(DashboardFolder), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<DashboardFolder>> CreateFolderAsync([FromBody] DashboardFolder folder)
        {
            var folders = await _context.Folders.GetAsync();
            PositionAdjuster.AdjustForCreate(folder, folders.ToList<ISortable>(), folder.Definitions.ToList<ISortable>());

            await _context.Folders.AddAsync(folder);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetFolder", new { id = folder.Id }, folder);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DashboardFolder), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DashboardFolder>> UpdateFolderAsync(int id, [FromBody] DashboardFolder folder)
        {
            var current = await FetchFolderAsync(id);
            if (current == null)
            {
                return NotFound();
            }

            var folders = await _context.Folders.GetAsync();
            PositionAdjuster.AdjustForUpdate(folder, folders.ToList<ISortable>(), current, folder.Definitions.ToList<ISortable>());

            current.UpdateFrom(folder);
            _context.Folders.Update(current);
            await _context.SaveChangesAsync();

            return current;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> DeleteFolderAsync(int id)
        {
            var folder = await _context.Folders.GetAsync(id);
            if (folder == null)
            {
                return NotFound();
            }
            else
            {
                var folders = await _context.Folders.GetAsync();
                PositionAdjuster.AdjustForDelete(folder, folders.ToList<ISortable>());

                _context.Folders.Delete(folder);
                await _context.SaveChangesAsync();

                return id;
            }
        }
    }
}
