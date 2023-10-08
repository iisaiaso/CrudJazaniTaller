using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Generals.Configurations
{
    public class InvestmentConceptConfiguration : IEntityTypeConfiguration<InvestmentConcept>
    {
        void IEntityTypeConfiguration<InvestmentConcept>.Configure(EntityTypeBuilder<InvestmentConcept> builder)
        {
             builder.ToTable("investmentconcept", "mc");
             builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
             builder.Property(x => x.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
             builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
