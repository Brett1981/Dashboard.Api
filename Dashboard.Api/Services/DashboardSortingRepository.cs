using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Services
{
    public class DashboardSortingRepository<T> : DbSortingRepository<T> where T : EntityBase, ISortable
    {
        public DashboardSortingRepository(DashboardDbContext context)
            : base(context)
        {
        }
    }
}
