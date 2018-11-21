using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardDefinition : EntityBase, ISortable
    {
        public List<DashboardTag> Tags { get; set; }
        public int Position { get; set; }

        public void UpdateFrom(DashboardDefinition fromDefinition)
        {
            base.UpdateFrom(fromDefinition);

            Tags.Clear();
            Tags.AddRange(fromDefinition.Tags);
        }
    }
}
