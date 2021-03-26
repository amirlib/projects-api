using ProjectsApi.Entities;

namespace ProjectsApi.Models
{
    public class ProjectModel
    {
        #region Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public int BugsCount { get; set; }
        public int DurationInDays { get; set; }
        public int Score { get; set; }
        public bool MadeDadeline { get; set; }
        #endregion

        #region Public Methods
        public static ProjectModel ToProjectModel(Project project)
        {
            return new ProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                BugsCount = project.BugsCount,
                DurationInDays = project.DurationInDays,
                Score = project.Score,
                MadeDadeline = project.MadeDadeline,
            };
        }
        #endregion
    }
}
