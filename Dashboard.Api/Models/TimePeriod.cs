using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class TimePeriod : EntityBase, IUpdatable<TimePeriod>
    {
        // default time period is last 5 minutes
        public TimePeriodType Type { get; set; }
        public RelativeTimeScale TimeScale { get; set; } = RelativeTimeScale.Minutes;
        public int OffsetFromNow { get; set; } = -5;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DashboardDefinitionId { get; set; }

        public void UpdateFrom(TimePeriod timePeriod)
        {
            Type = timePeriod.Type;
            TimeScale = timePeriod.TimeScale;
            OffsetFromNow = timePeriod.OffsetFromNow;
            StartTime = timePeriod.StartTime;
            EndTime = timePeriod.EndTime;
            DashboardDefinitionId = timePeriod.DashboardDefinitionId;
        }
    }
}
