using Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DefinitionElement : DashboardElement, IUpdatable<DefinitionElement>
    {
        public int DashboardFolderId { get; set; }

        public void UpdateFrom(DefinitionElement fromEntity)
        {
            base.UpdateFrom(fromEntity);
            DashboardFolderId = fromEntity.DashboardFolderId;
        }
    }
}
