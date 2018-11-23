using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardDefinition : EntityBase, ISortable
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<DashboardTag> Tags { get; set; }
        public int Position { get; set; }

        public void UpdateFrom(DashboardDefinition fromDefinition)
        {
            Position = fromDefinition.Position;
            Name = fromDefinition.Name;
            Title = fromDefinition.Title;

            Tags.Clear();
            Tags.AddRange(fromDefinition.Tags);
        }
    }
}
