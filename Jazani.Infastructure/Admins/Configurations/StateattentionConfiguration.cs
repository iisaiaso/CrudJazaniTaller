using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Admins.Configurations
{
    public class StateattentionConfiguration : IEntityTypeConfiguration<Stateattention>
    {
        void IEntityTypeConfiguration<Stateattention>.Configure(EntityTypeBuilder<Stateattention> builder)
        {
            builder.ToTable("stateattention", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
