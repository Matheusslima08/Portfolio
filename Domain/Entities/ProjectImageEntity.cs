using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [PrimaryKey(nameof(ProjectImageID))]
    public class ProjectImageEntity
    {
        public long ProjectImageID { get; set; }

        [ForeignKey(nameof(ProjectID))]
        public long ProjectID { get; set; }
        public virtual ProjectEntity? Project { get; set; }

        
        public string Image { get; set; }


        [ForeignKey(nameof(ProjectImageTypeID))]
        public int ProjectImageTypeID { get; set; }
        public virtual ProjectImageTypeEntity? ProjectImageType { get; set; }
    }
}
