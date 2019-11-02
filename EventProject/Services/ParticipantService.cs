using System.Collections.Generic;
using EventProject.Models;
using MongoDB.Driver;

namespace EventProject.Services
{
    public class ParticipantService
    {
        private readonly IMongoCollection<Participant> _participant;

        public ParticipantService(IEventDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _participant = database.GetCollection<Participant>(settings.ParticipantsCollectionName);
        }

        public List<Participant> Get() =>
            _participant.Find(participant => true).ToList();

        public Participant Get(string id) =>
            _participant.Find<Participant>(participant => participant.Id == id).FirstOrDefault();

        public Participant Create(Participant participant)
        {
            _participant.InsertOne(participant);
            return participant;
        }

        public void Update(string id, Participant participantIn) =>
            _participant.ReplaceOne(participant => participant.Id == id, participantIn);

        public void Remove(Participant participantIn) =>
            _participant.DeleteOne(participant => participant.Id == participantIn.Id);

        public void Remove(string id) => 
            _participant.DeleteOne(participant => participant.Id == id);
    }
}