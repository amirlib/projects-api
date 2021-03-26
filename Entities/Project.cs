using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectsApi.Entities
{
    public class Project
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int BugsCount { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public bool MadeDadeline { get; set; }
    }
}
