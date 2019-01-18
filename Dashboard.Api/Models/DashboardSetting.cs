using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardSetting : EntityBase, IUpdatable<DashboardSetting>
    {
        public int SettingId { get; set; }
        public double? NumberValue { get; set; }
        public bool? BooleanValue { get; set; }
        public string StringValue { get; set; }
        public DateTime? DateValue { get; set; }
        public int DashboardDefinitionId { get; set; }

        public void UpdateFrom(DashboardSetting fromSetting)
        {
            SettingId = fromSetting.SettingId;
            NumberValue = fromSetting.NumberValue;
            BooleanValue = fromSetting.BooleanValue;
            StringValue = fromSetting.StringValue;
            DateValue = fromSetting.DateValue;
        }
    }
}
