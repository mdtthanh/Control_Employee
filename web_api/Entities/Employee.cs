namespace web_api.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int? WorkPlaceId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? WorkTime { get; set; }
        public WorkPlace? WorkPlace { get; set; }
    }
}
