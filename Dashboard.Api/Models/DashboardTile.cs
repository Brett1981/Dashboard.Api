﻿using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardTile : EntityBase, ISortable, IUpdatable<DashboardTile>
    {
        public int TagId { get; set; }
        public bool Important { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public int DashboardDefinitionId { get; set; }
        public int Position { get; set; }

        public void UpdateFrom(DashboardTile fromTag)
        {
            TagId = fromTag.TagId;
            Important = fromTag.Important;
            ColumnSpan = fromTag.ColumnSpan;
            RowSpan = fromTag.RowSpan;
            Position = fromTag.Position;
            DashboardDefinitionId = fromTag.DashboardDefinitionId;
        }
    }
}