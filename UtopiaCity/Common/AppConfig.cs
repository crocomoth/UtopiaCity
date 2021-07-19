namespace UtopiaCity.Common
{
    /// <summary>
    /// Represents application configuration.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Flag to clear database by each set.
        /// </summary>
        public bool ClearDb { get; set; }
        /// <summary>
        /// Flag to populate database for each set.
        /// </summary>
        public bool SeedDb { get; set; }
    }
}
