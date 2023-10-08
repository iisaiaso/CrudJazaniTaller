namespace Jazani.Domain.Generals.Models
{
    public class Holder
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName{ get; set; }
        public string? Address { get; set; }
        public string? CorporatEmail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        //Para que haya relacion 
        public virtual ICollection<Investment>? Investments { get; set; }

    }
}
