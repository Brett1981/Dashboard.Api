using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class DashboardDefinition : DefinitionElement, IUpdatable<DashboardDefinition>
    {
        public int Columns { get; set; }
        public RequestType RequestType { get; set; }
        public DateTime? ValueAtTimeTarget { get; set; }
        public TimePeriod HistoryTimePeriod { get; set; }
        public List<DashboardTile> Tiles { get; set; } = new List<DashboardTile>();
        public List<DashboardSetting> Settings { get; set; } = new List<DashboardSetting>();

        public void UpdateFrom(DashboardDefinition fromDefinition)
        {
            base.UpdateFrom(fromDefinition);

            Columns = fromDefinition.Columns;
            RequestType = fromDefinition.RequestType;
            ValueAtTimeTarget = fromDefinition.ValueAtTimeTarget;
            if (fromDefinition.HistoryTimePeriod == null)
            {
                HistoryTimePeriod = null;
            }
            else
            {
                if (HistoryTimePeriod == null)
                {
                    HistoryTimePeriod = new TimePeriod();
                }
                HistoryTimePeriod.UpdateFrom(fromDefinition.HistoryTimePeriod);
            }
            CollectionUpdater<DashboardTile>.Update(Tiles, fromDefinition.Tiles);
            CollectionUpdater<DashboardSetting>.Update(Settings, fromDefinition.Settings);
        }

        public DefinitionElement ToElement()
        {
            return new DefinitionElement()
            {
                Id = Id,
                Name = Name,
                Position = Position,
                DashboardFolderId = DashboardFolderId
            };
        }
    }
}
