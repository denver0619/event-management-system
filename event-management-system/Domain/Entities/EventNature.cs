namespace event_management_system.Domain.Entities
{
    public class EventNature : IEventNature
    {
        public EventNature() { }
        public EventNature(string eventNatureID,
            string natureName,
            string natureDescription)
        {
            EventNatureID = eventNatureID;
            NatureName = natureName;
            NatureDescription = natureDescription;
        }
        public EventNature(IEventNature eventNature)
        {
            EventNatureID =  eventNature.EventNatureID;
            NatureName = eventNature.NatureName;
            NatureDescription = eventNature.NatureDescription;
        }

        public string? EventNatureID { get; set; }
        public string? NatureName { get; set; }
        public string? NatureDescription { get; set; }
    }
}
