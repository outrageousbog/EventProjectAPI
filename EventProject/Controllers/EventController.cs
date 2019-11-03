using System.Collections.Generic;
using System.Collections.Specialized;
using EventProject.Models;
using EventProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<List<Event>> Get() =>
            _eventService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEvent")]
        public ActionResult<Event> Get(string id)
        {
            var eventTmp = _eventService.Get(id);

            if (eventTmp == null)
            {
                return NotFound();
            }

            return eventTmp;
        }

        [HttpPost]
        public ActionResult<Event> Create(Event eventTmp)
        {
            _eventService.Create(eventTmp);
            return CreatedAtRoute("GetEvent",
                new {id = eventTmp.Id},
                eventTmp);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var eventTmp = _eventService.Get(id);

            if (eventTmp == null)
            {
                return NotFound();
            }

            _eventService.Remove(eventTmp.Id);

            return NoContent();
        }
    }
}