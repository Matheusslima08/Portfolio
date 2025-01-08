using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [PrimaryKey(nameof(ProjectStatusID))]
    public class ProjectStatusEntity
    {
        public int ProjectStatusID { get; set; }
        public string Name { get; set; }
    }
}
