using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardSortingRepository<T> : DbSortingRepository<T> where T : EntityBase, ISortable
    {
        public DashboardSortingRepository(DashboardContext context)
            : base(context)
        {
        }
    }
}
