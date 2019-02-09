using Api.Common;
using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Api.Models
{
    public class FolderElement : FolderBase, IUpdatable<FolderElement>
    {
        public int DefaultDefinitionId { get; set; }

        public void UpdateFrom(FolderElement fromEntity)
        {
            base.UpdateFrom(fromEntity);
            DefaultDefinitionId = fromEntity.DefaultDefinitionId;
        }
    }
}
