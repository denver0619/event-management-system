using event_management_system.Domain.Models;
using event_management_system.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;
using event_management_system.Domain.Entities;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace event_management_system.Controllers
{

    public class OrganizationEventsController : Controller
    {

        private readonly ILogger<OrganizationEventsController> _logger;

        public OrganizationEventsController(ILogger<OrganizationEventsController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            ViewData["OrganizationID"] = userID;
            return View();
        }

        public IActionResult ContentCreation()
        {

            return View();
        }


        [HttpPost]
        public IActionResult SendTextData([FromBody]CreateEventData eventEntity)
        {
           /* if (!ModelState.IsValid)
            {
                // The model is not valid, log validation errors
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

                foreach (var error in errors)
                {
                    _logger.LogError($"Validation Error: {error}");
                }

                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }*/



            Debug.WriteLine(JsonSerializer.Serialize(eventEntity));
            Event eventData = new Event();


            eventData.EventID = eventEntity.EventID;
            eventData.EventNatureID = eventEntity.EventNatureID;
            eventData.EventStatusID = eventEntity.EventStatusID;
            eventData.OrganizationID = eventEntity.OrganizationID;
            eventData.Venue = eventEntity.Venue;
            eventData.Title = eventEntity.Title;
            eventData.DatePosted = eventEntity.DatePosted;
            eventData.DateStart = eventEntity.DateStart;
            eventData.DateEnd = eventEntity.DateEnd;
            eventData.ParticipantNumber = eventEntity.ParticipantNumber;
            eventData.EventType = eventEntity.EventType;
            eventData.ContactPerson = eventEntity.ContactPerson;
            eventData.ContactNumber = eventEntity.ContactNumber;
            eventData.FeedbackLink = eventEntity.FeedbackLink;
            eventData.PaymentLink = eventEntity.PaymentLink;
            eventData.Description = eventEntity.Description;

            eventData.DatePosted = DateTime.Now;
            EventCreateEditService eventCreateEditService = new EventCreateEditService();

            eventCreateEditService.AddEvent(eventData);
            eventCreateEditService.Dispose();


            return Ok();
        }


        public IActionResult EventsUpcoming() 
        {
            string userID = HttpContext.Request.Query["userId"]!;

            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllUpcomingEventsByOrganizationID(userID);
            eventsServices.Dispose();

            // get list of upcoming based on orgID then return as model
            return PartialView("EventCategory/EventsUpcoming", eventsModel);
            // return PartialView("EventCategory/EventsUpcoming", modelHere);
        }

        public IActionResult EventsPrevious()
        {
            string userID = HttpContext.Request.Query["userId"]!;

            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllPreviousEventsByOrganizationID(userID);
            eventsServices.Dispose();

            // get list of previous based on orgID then return as model
            return PartialView("EventCategory/EventsPrevious", eventsModel);
        }

        public IActionResult EventMain()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            ViewData["OrganizationID"] = userID;
            Debug.WriteLine("main org " + userID);


            string eventID = HttpContext.Request.Query["eventId"]!;
            TempData["EventId"] = eventID;
            ViewData["EventID"] = eventID;
            Debug.WriteLine("main " + eventID);
            return View();
        }



        public IActionResult EventDetails()
        {
            // Use the name 'eventId' to match the query parameter
            string eventId = HttpContext.Request.Query["eventId"]!;

            EventCreateEditService eventsService = new EventCreateEditService();
            EventCreateEditModel eventCreateEditModel = eventsService.GetEventData(eventId);
            eventsService.Dispose();

            return PartialView("EventManagement/EventDetails", eventCreateEditModel);
        }

        [HttpPost]
        public IActionResult EditEvent([FromBody]Event eventEntity)
        {
            eventEntity.DatePosted = DateTime.Now;
            Debug.WriteLine(JsonSerializer.Serialize(eventEntity));
            EventCreateEditService editService = new EventCreateEditService();
            editService.UpdateEvent(eventEntity);
            editService.Dispose();

            return Ok();
        }

        public IActionResult EventAttendanceLog()
        {
            // Use the name 'eventId' to match the query parameter
            string eventId = HttpContext.Request.Query["eventId"]!;


            // Handle the eventId as needed

            return PartialView("EventManagement/EventAttendanceLog");
        }



        public IActionResult EventAttendees()
        {
            string eventId = HttpContext.Request.Query["eventId"]!;
            Debug.WriteLine("att " + eventId);

            /*AttendeeManagementService attendeeManagementService = new AttendeeManagementService();
            AttendeeManagementModel attendeeManagementModel = attendeeManagementService;*/

            return PartialView("EventManagement/EventAttendees");
        }



    }

    public class EventDetailsModel
    {
        /* public string? EventID { get; set; }
         public string? EventNatureID { get; set; }
         public string? EventStatusID { get; set; }
         public string? OrganizationID { get; set; }
        *//* public string DateStart { get; set; }
         public string DateEnd { get; set; }*//*
         public string? Venue { get; set; }
         public string? Title { get; set; }
         public int? ParticipantNumber { get; set; }
         public string? EventType { get; set; }
         public string? ContactPerson { get; set; }
         public string? ContactNumber { get; set; }
         public string? FeedbackLink { get; set; }
         public string? PaymentLink { get; set; }
         public string? Description { get; set; }*/
        public EventDetailsModel() { }
        public EventDetailsModel(string eventID,
            string eventNatureID,
            string eventStatusID,
            string organizationID,
            string venue,
            string title,
            int participantNumber,
            string eventType,
            string contactPerson,
            string contactNumber,
            string feedbackLink,
            string paymentLink,
            string description)
        {
            EventID = eventID;
            EventNatureID = eventNatureID;
            EventStatusID = eventStatusID;
            OrganizationID = organizationID;
            Venue = venue;
            Title = title;
            ParticipantNumber = participantNumber;
            EventType = eventType;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            FeedbackLink = feedbackLink;
            PaymentLink = paymentLink;
            Description = description;
        }

        public EventDetailsModel(IEvent eventEntity)
        {
            EventID = eventEntity.EventID;
            EventNatureID = eventEntity.EventNatureID;
            EventStatusID = eventEntity.EventStatusID;
            OrganizationID = eventEntity.OrganizationID;
            Venue = eventEntity.Venue;
            Title = eventEntity.Title;
            ParticipantNumber = eventEntity.ParticipantNumber;
            EventType = eventEntity.EventType;
            ContactPerson = eventEntity.ContactPerson;
            ContactNumber = eventEntity.ContactNumber;
            FeedbackLink = eventEntity.FeedbackLink;
            PaymentLink = eventEntity.PaymentLink;
            Description = eventEntity.Description;
        }

        public string? EventID { get; set; }
        public string? EventNatureID { get; set; }
        public string? EventStatusID { get; set; }
        public string? OrganizationID { get; set; }
        public string? Venue { get; set; }

        public string? Title { get; set; }
        public int ParticipantNumber { get; set; }
        public string? EventType { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeedbackLink { get; set; }
        public string? PaymentLink { get; set; }
        public string? Description { get; set; }

    }

    public class CombinedDataModel
    {
        [FromForm(Name = "Image")]
        public IFormFile Image { get; set; }

        [FromBody]
        public EventDetailsModel EventDetails { get; set; }
    }


/*    public class ImageDataModel
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageDataBase64 => ImageData != null ? Convert.ToBase64String(ImageData) : null;
    }*/



    public class CreateEventData
    {
        public CreateEventData() { }
        public CreateEventData(string eventID,
            string eventNatureID,
            string eventStatusID,
            string organizationID,
            string venue,
            string title,
            DateTime datePosted,
            DateTime dateStart,
            DateTime dateEnd,
            int participantNumber,
            string eventType,
            string contactPerson,
            string contactNumber,
            string feedbackLink,
            string paymentLink,
            string description)
        {
            EventID = eventID;
            EventNatureID = eventNatureID;
            EventStatusID = eventStatusID;
            OrganizationID = organizationID;
            Venue = venue;
            Title = title;
            DatePosted = datePosted;
            DateStart = dateStart;
            DateEnd = dateEnd;
            ParticipantNumber = participantNumber;
            EventType = eventType;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            FeedbackLink = feedbackLink;
            PaymentLink = paymentLink;
            Description = description;
        }

        public CreateEventData(IEvent eventEntity)
        {
            EventID = eventEntity.EventID;
            EventNatureID = eventEntity.EventNatureID;
            EventStatusID = eventEntity.EventStatusID;
            OrganizationID = eventEntity.OrganizationID;
            Venue = eventEntity.Venue;
            Title = eventEntity.Title;
            DatePosted = eventEntity.DatePosted;
            DateStart = eventEntity.DateStart;
            DateEnd = eventEntity.DateEnd;
            ParticipantNumber = eventEntity.ParticipantNumber;
            EventType = eventEntity.EventType;
            ContactPerson = eventEntity.ContactPerson;
            ContactNumber = eventEntity.ContactNumber;
            FeedbackLink = eventEntity.FeedbackLink;
            PaymentLink = eventEntity.PaymentLink;
            Description = eventEntity.Description;
        }

        public string? EventID { get; set; }
        public string? EventNatureID { get; set; }
        public string? EventStatusID { get; set; }
        public string? OrganizationID { get; set; }
        public string? Venue { get; set; }
        public DateTime? DatePosted{ get; set; }
        public DateTime? DateStart{ get; set; }
        public DateTime? DateEnd{ get; set; }
        public string? Title { get; set; }
        public int ParticipantNumber { get; set; }
        public string? EventType { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeedbackLink { get; set; }
        public string? PaymentLink { get; set; }
        public string? Description { get; set; }

        public byte[] Image { get; set; }
    }
}
