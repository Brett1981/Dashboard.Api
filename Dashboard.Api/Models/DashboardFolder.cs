using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardFolder : FolderBase, IUpdatable<DashboardFolder>
    {
        public List<DashboardDefinition> Definitions { get; set; } = new List<DashboardDefinition>();

        public void UpdateFrom(DashboardFolder fromEntity)
        {
            base.UpdateFrom(fromEntity);
            CollectionUpdater<DashboardDefinition>.Update(Definitions, fromEntity.Definitions);
        }

        public FolderElement ToElement()
        {
            return new FolderElement()
            {
                Id = Id,
                Name = Name,
                Position = Position,
                KioskInterval = KioskInterval,
                KioskTimeScale = KioskTimeScale,
                DefaultDefinitionId = Definitions.Count > 0 ? Definitions[0].Id : 0
            };
        }
    }
}
