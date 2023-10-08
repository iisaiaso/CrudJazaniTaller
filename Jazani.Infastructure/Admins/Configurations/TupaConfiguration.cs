using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Admins.Configurations
{
    public class InvestmentConfiguration1 : IEntityTypeConfiguration<Tupa>
    {
        void IEntityTypeConfiguration<Tupa>.Configure(EntityTypeBuilder<Tupa> builder) 
        {
            builder.ToTable("tupa", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
