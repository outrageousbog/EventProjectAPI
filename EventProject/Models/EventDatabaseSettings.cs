namespace EventProject.Models
{
    public class EventDatabaseSettings : IEventDatabaseSettings
    {
        public string ParticipantsCollectionName { get; set; }
        public string EventsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEventDatabaseSettings
    {
        string ParticipantsCollectionName { get; set; }
        string EventsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}