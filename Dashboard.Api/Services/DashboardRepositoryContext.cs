using Api.Common.Repository;
using Dashboard.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Services
{
    public class DashboardRepositoryContext : DbRepositoryContext, IDashboardRepositoryContext
    {
        public IRepository<DashboardFolder> Folders { get; private set; }
        public IRepository<DashboardDefinition> Definitions { get; private set; }

        public DashboardRepositoryContext(DashboardDbContext context)
            : base(context)
        {
            Folders = new DashboardSortingRepository<DashboardFolder>((DashboardDbContext)_context);
            Definitions = new DashboardSortingRepository<DashboardDefinition>((DashboardDbContext)_context);
        }
    }
}
