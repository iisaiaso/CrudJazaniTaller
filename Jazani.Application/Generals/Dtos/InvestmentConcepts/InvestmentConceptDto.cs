namespace Jazani.Application.Generals.Dtos.InvestmentConcepts
{

    public class InvestmentConceptDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }

}
