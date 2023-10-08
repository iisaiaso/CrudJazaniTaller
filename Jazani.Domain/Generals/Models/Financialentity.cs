namespace Jazani.Domain.Generals.Models
{
    public class Financialentity
    {
        public int  Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Ruc { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State {  get; set; }

        public ICollection<Pay>? Pays { get; set; }

    }
}
