namespace event_management_system.Domain.Entities
{
    public class Event : IEvent
    {
        public Event() { }
        public Event(string eventID, 
            string eventNatureID, 
            string eventStatusID, 
            string organizationID, 
            DateTime datePosted,
            DateTime dateStart,
            DateTime dateEnd,
            string venue,
            string image,
            string title,
            int numberOfParticipants,
            string typeOfEvent,
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
            NumberOfParticipants = numberOfParticipants;
            TypeOfEvent = typeOfEvent;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            FeedbackLink = feedbackLink;
            PaymentLink = paymentLink;
            Description = description;
        }

        public Event(IEvent eventEntity)
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
            NumberOfParticipants = eventEntity.NumberOfParticipants;
            TypeOfEvent = eventEntity.TypeOfEvent;
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
        public int NumberOfParticipants { get; set; }
        public string? TypeOfEvent { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeedbackLink { get; set; }
        public string? PaymentLink { get; set; }
        public string? Description { get; set; }
    }
}
