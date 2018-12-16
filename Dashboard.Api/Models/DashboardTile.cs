using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardTile : EntityBase, ISortable, IUpdatable<DashboardTile>
    {
        public int SourceId { get; set; }
        public bool Important { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public int Position { get; set; }
        public int DashboardDefinitionId { get; set; }

        public void UpdateFrom(DashboardTile fromTag)
        {
            SourceId = fromTag.SourceId;
            Important = fromTag.Important;
            ColumnSpan = fromTag.ColumnSpan;
            RowSpan = fromTag.RowSpan;
            Position = fromTag.Position;
        }
    }
}
