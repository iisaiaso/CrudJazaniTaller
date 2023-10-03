namespace Jazani.Domain.Admins.Models
{
    public class Stateattention
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
