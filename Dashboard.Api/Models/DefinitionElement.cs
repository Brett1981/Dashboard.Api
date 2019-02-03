using Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DefinitionElement : DashboardElement
    {
        public int DashboardFolderId { get; set; }
    }
}
