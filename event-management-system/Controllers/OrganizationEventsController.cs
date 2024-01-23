using event_management_system.Domain.Models;
using event_management_system.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;
using event_management_system.Domain.Entities;
using System.Text.Json;

namespace event_management_system.Controllers
{

    public class OrganizationEventsController : Controller
    {
        public IActionResult Index()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);
            return View();
        }

        public IActionResult ContentCreation()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SendImageData([FromForm] CombinedDataModel combinedData)
        {
            try
            {
                // Access the image using combinedData.Image
                // Access event details using combinedData.EventDetails

                // Your logic to process the data goes here

                // For demonstration purposes, returning a simple JSON response
                var responseData = new
                {
                    Message = "Data received successfully",
                    ImageData = "base64encodedimagestring" // You can replace this with your actual image data
                };

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error: {ex.Message}" });
            }
        }












        public IActionResult EventMain()
        {
            
            

            return View();
        }



        public IActionResult EventsUpcoming() 
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);

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
            Debug.WriteLine(userID);

            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllPreviousEventsByOrganizationID(userID);
            eventsServices.Dispose();

            // get list of previous based on orgID then return as model
            return PartialView("EventCategory/EventsPrevious", eventsModel);
        }



        public IActionResult EventDetails(string EventID)
        {
            return PartialView("EventManagement/EventDetails");

        }
        public IActionResult EventAttendees(string EventID)
        {
            return PartialView("EventManagement/EventAttendees");
        }

        public IActionResult EventAttendanceLog(string EventID)
        {
            return PartialView("EventManagement/EventAttendanceLog");
        }
        

    }

    public class EventDetailsModel
    {
        public string EventID { get; set; }
        public string EventNatureID { get; set; }
        public string EventStatusID { get; set; }
        public string OrganizationID { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Venue { get; set; }
        public string Title { get; set; }
        public int ParticipantNumber { get; set; }
        public string EventType { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string FeedbackLink { get; set; }
        public string PaymentLink { get; set; }
        public string Description { get; set; }
    }

    public class CombinedDataModel
    {
        public IFormFile Image { get; set; }
        public EventDetailsModel EventDetails { get; set; }
    }

    /*    public class ImageDataModel
        {
            public int Id { get; set; }
            public byte[] ImageData { get; set; }
            public string ImageDataBase64 => ImageData != null ? Convert.ToBase64String(ImageData) : null;
        }



        public class CreateEventData
        {
            public CreateEventData() { }
            public CreateEventData(string eventID,
                string eventNatureID,
                string eventStatusID,
                string organizationID,
               *//* DateTime datePosted,
                DateTime dateStart,
                DateTime dateEnd,*//*
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
               *//* DatePosted = datePosted;
                DateStart = dateStart;
                DateEnd = dateEnd;*//*
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

            public CreateEventData(IEvent eventEntity)
            {
                EventID = eventEntity.EventID;
                EventNatureID = eventEntity.EventNatureID;
                EventStatusID = eventEntity.EventStatusID;
                OrganizationID = eventEntity.OrganizationID;
                *//*DatePosted = eventEntity.DatePosted;
                DateStart = eventEntity.DateStart;
                DateEnd = eventEntity.DateEnd;*//*
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
            *//*public DateTime? DatePosted { get; set; }
            public DateTime? DateStart { get; set; }
            public DateTime? DateEnd { get; set; }*//*
            public string? Venue { get; set; }

            public string? Title { get; set; }
            public int ParticipantNumber { get; set; }
            public string? EventType { get; set; }
            public string? ContactPerson { get; set; }
            public string? ContactNumber { get; set; }
            public string? FeedbackLink { get; set; }
            public string? PaymentLink { get; set; }
            public string? Description { get; set; }

            public byte[] ImageData { get; set; }
            public string ImageDataBase64 => ImageData != null ? Convert.ToBase64String(ImageData) : null;
        }*/
}
