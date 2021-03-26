using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsApi.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjectsApi.Configuration
{
    /// <summary>
    /// Configuration class for Project Entity
    /// </summary>
    public class ProjectsConfiguration : IEntityTypeConfiguration<Project>
    {
        #region Public Methods
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            var projects = DeserializeJsonUsersFile();

            builder.ToTable("Projects");
            builder.HasData(projects);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Deserilze the projects.json file to seed the db with initial data
        /// </summary>
        /// <returns>List of projects</returns>
        private IEnumerable<Project> DeserializeJsonUsersFile()
        {
            var jsonString = File.ReadAllText("projects.json");

            return JsonSerializer.Deserialize<List<Project>>(jsonString);
        }
        #endregion
    }
}
