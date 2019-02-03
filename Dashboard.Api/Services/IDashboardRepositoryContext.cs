using Api.Common.Repository;
using Dashboard.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Services
{
    public interface IDashboardRepositoryContext : IRepositoryContext
    {
        IRepository<DashboardFolder> Folders { get; }
        IRepository<DashboardDefinition> Definitions { get; }
    }
}
