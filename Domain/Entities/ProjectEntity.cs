using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [PrimaryKey(nameof(ProjectID))]
    public class ProjectEntity
    {
        public long ProjectID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Link { get; set; }

        [ForeignKey(nameof(ProjectStatusID))]
        public int ProjectStatusID { get; set; }
        public virtual ProjectStatusEntity? ProjectStatus { get; set; }
    }
}
