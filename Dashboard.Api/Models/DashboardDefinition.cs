using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardDefinition : EntityBase, ISortable, IUpdatable<DashboardDefinition>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<DashboardTag> Tags { get; set; } = new List<DashboardTag>();
        public int Position { get; set; }

        public void UpdateFrom(DashboardDefinition fromDefinition)
        {
            Position = fromDefinition.Position;
            Name = fromDefinition.Name;
            Title = fromDefinition.Title;

            CollectionUpdater<DashboardTag>.Update(Tags, fromDefinition.Tags);
        }
    }
}
