using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsApi.Entities;
using ProjectsApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProjectsApi.Configuration
{
    /// <summary>
    /// Configuration class for User Entity
    /// </summary>
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        #region Public Methods
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var users = DeserializeJsonUsersFile();

            builder.ToTable("Users");
            builder.HasData(users);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Deserilze the users.json file to seed the db with initial data
        /// </summary>
        /// <returns>List of users</returns>
        private IEnumerable<User> DeserializeJsonUsersFile()
        {
            var jsonString = File.ReadAllText("users.json");
            var users = JsonSerializer.Deserialize<List<UserJsonModel>>(jsonString);

            return users.Select(u =>
            {
                var user = new User
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    Team = u.Team,
                    JoinedAt = DateTime.Parse(u.JoinedAt),
                };

                CreatePasswordHash(u.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                return user;
            });
        }
        /// <summary>
        /// Hashes the original password and saving the salt value and the hashed password
        /// </summary>
        /// <param name="password">Original password</param>
        /// <param name="passwordHash">Hashed password in bytes</param>
        /// <param name="passwordSalt">Salt value in bytes</param>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        } 
        #endregion
    }
}
