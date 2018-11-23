using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardTag : EntityBase, IUpdatable<DashboardTag>
    {
        public int Tag { get; set; }
        public int DashboardDefinitionId { get; set; }

        public void UpdateFrom(DashboardTag fromTag)
        {
            Tag = fromTag.Tag;
            DashboardDefinitionId = fromTag.DashboardDefinitionId;
        }
    }
}
