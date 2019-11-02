using System.Collections.Generic;
using EventProject.Models;
using EventProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantService _participantService;

        public ParticipantController(ParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public List<Participant> Get() =>
            _participantService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetParticipant")]
        public ActionResult<Participant> Get(string id)
        {
            var participant = _participantService.Get(id);
        
            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }
        
        [HttpPost]
        public ActionResult<Participant> Create(Participant participantTmp)
        {
            _participantService.Create(participantTmp);
            return CreatedAtRoute("GetParticipant", new {id = participantTmp.Id.ToString()});
        }
    }
}