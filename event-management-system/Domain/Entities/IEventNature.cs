namespace event_management_system.Domain.Entities
{
    public interface IEventNature
    {
        public string? EventNatureID { get; set; }
        public string? NatureName { get; set; }
        public string? NatureDescription { get; set; }
    }
}
