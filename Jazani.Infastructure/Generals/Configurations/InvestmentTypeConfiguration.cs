using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Generals.Configurations
{
    internal class InvestmentTypeConfiguration : IEntityTypeConfiguration<InvestmentType>
    {
        void IEntityTypeConfiguration<InvestmentType>.Configure(EntityTypeBuilder<InvestmentType> builder)
        {
            builder.ToTable("investmenttype", "mc");
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
