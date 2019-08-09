namespace TempApi.Models
{
    public class TempDbSettings : ITempDbSettings
    {
        public string TempCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITempDbSettings
    {
        string TempCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}