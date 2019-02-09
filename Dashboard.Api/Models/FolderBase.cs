using Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class FolderBase : DashboardElement, IUpdatable<FolderBase>
    {
        public int KioskInterval { get; set; }
        public KioskTimeScale KioskTimeScale { get; set; }

        public void UpdateFrom(FolderBase fromEntity)
        {
            base.UpdateFrom(fromEntity);
            KioskInterval = fromEntity.KioskInterval;
            KioskTimeScale = fromEntity.KioskTimeScale;
        }
    }
}
