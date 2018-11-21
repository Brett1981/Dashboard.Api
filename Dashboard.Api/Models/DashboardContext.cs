using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        public DbSet<DashboardDefinition> DashboardDefinitions { get; set; }
    }
}