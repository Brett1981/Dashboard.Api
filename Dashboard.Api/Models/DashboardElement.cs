using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardElement : EntityBase, ISortable, IUpdatable<DashboardElement>
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public void UpdateFrom(DashboardElement fromEntity)
        {
            Name = fromEntity.Name;
            Position = fromEntity.Position;
        }
    }
}
