using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardRepositoryContext : DbRepositoryContext, IDashboardRepositoryContext
    {
        public IRepository<DashboardDefinition> Definitions { get; private set; }

        public DashboardRepositoryContext(DashboardContext context)
            : base(context)
        {
            Definitions = new DashboardSortingRepository<DashboardDefinition>((DashboardContext)_context);
        }
    }
}
