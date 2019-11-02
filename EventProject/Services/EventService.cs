using System.Collections.Generic;
using EventProject.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventProject.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _event;

        public EventService(IEventDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb+srv://outrageousbog:45TJ9tsqPr8iF.n@cluster0-myojh.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("EventsDb");

            _event = database.GetCollection<Event>("Events");
        }

        public List<Event> Get() =>
            _event.Find(eventTmp => true).ToList();

        public Event Get(string id) =>
            _event.Find<Event>(eventTmp => eventTmp.Id == id).FirstOrDefault();

        public Event Create(Event eventIn)
        {
            _event.InsertOne(eventIn);
            return eventIn;
        }

        public void Update(string id, Event eventIn) =>
            _event.ReplaceOne(eventTmp => eventTmp.Id == id, eventIn);

        public void Remove(Event eventIn) =>
            _event.DeleteOne(eventTmp => eventTmp.Id == eventIn.Id);

        public void Remove(string id) => 
            _event.DeleteOne(eventTmp => eventTmp.Id == id);

        public List<Event> GetParticipantEvents(string id)
        {
            var filter = Builders<Event>.Filter.Eq("participants", id);
            var events = _event.Find(filter).ToList();
            return events;
        }
    }
}