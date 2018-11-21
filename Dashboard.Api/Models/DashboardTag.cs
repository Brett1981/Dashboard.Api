using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardTag : EntityBase
    {
        public int Tag { get; set; }
        public int DashboardDefinitionId { get; set; }
    }
}
