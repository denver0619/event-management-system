using event_management_system.Domain.Entities;

namespace event_management_system.Domain.DataTransferObject
{
    public class EventDataTransferObject : IEvent
    {
        public EventDataTransferObject() { }
        public EventDataTransferObject(string eventID,
            string eventNatureID,
            string eventStatusID,
            string organizationID,
            DateTime datePosted,
            DateTime dateStart,
            DateTime dateEnd,
            string venue,
            string? image,
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
            DatePosted = datePosted;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Venue = venue;
            Image = image;
            Title = title;
            ParticipantNumber = participantNumber;
            EventType = eventType;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            FeedbackLink = feedbackLink;
            PaymentLink = paymentLink;
            Description = description;
        }

        public EventDataTransferObject(IEvent eventEntity)
        {
            EventID = eventEntity.EventID;
            EventNatureID = eventEntity.EventNatureID;
            EventStatusID = eventEntity.EventStatusID;
            OrganizationID = eventEntity.OrganizationID;
            DatePosted = eventEntity.DatePosted;
            DateStart = eventEntity.DateStart;
            DateEnd = eventEntity.DateEnd;
            Venue = eventEntity.Venue;
            Image = eventEntity.Image;
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
        public DateTime? DatePosted { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Venue { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public int ParticipantNumber { get; set; }
        public string? EventType { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeedbackLink { get; set; }
        public string? PaymentLink { get; set; }
        public string? Description { get; set; }

        public IEventNature? Nature { get; set; }
        public IEventStatus? Status { get; set; }
        public IOrganization? Organization { get; set; }
    }
}
