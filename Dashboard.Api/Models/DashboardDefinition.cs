using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardDefinition : DashboardElement, IUpdatable<DashboardDefinition>
    {
        public string Title { get; set; }
        public int Columns { get; set; }
        public List<DashboardTile> Tiles { get; set; } = new List<DashboardTile>();

        public void UpdateFrom(DashboardDefinition fromDefinition)
        {
            base.UpdateFrom(fromDefinition);

            Title = fromDefinition.Title;
            Columns = fromDefinition.Columns;
            CollectionUpdater<DashboardTile>.Update(Tiles, fromDefinition.Tiles);
        }

        public DashboardElement ToElement()
        {
            return new DashboardElement()
            {
                Id = Id,
                Name = Name,
                Position = Position
            };
        }
    }
}
