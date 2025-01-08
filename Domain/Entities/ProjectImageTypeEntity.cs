using Microsoft.EntityFrameworkCore;

namespace Domain.Entities

{
    [PrimaryKey(nameof(ProjectImageTypeID))]
    public class ProjectImageTypeEntity
    {
        public int ProjectImageTypeID { get; set; }

        public string Name { get; set; }
    }
}
