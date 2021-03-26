namespace ProjectsApi.Models
{
    /// <summary>
    /// User's model for the json deserialization result 
    /// </summary>
    public class UserJsonModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string JoinedAt { get; set; }
    }
}
