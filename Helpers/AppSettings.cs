namespace ProjectsApi.Helpers
{
    /// <summary>
    /// Represents the data of AppSettings section in appsettimgs.json file
    /// </summary>
    public class AppSettings
    {
        #region Properties
        /// <summary>
        /// The JWT expires value in days
        /// </summary>
        public double ExpiresDays { get; set; }
        /// <summary>
        /// The secret value that JWT uses
        /// </summary>
        public string Secret { get; set; } 
        #endregion
    }
}
