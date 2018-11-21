using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public interface IDashboardRepositoryContext : IRepositoryContext
    {
        IRepository<DashboardDefinition> Definitions { get; }
    }
}
