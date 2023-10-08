using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Generals.Configurations
{
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        void IEntityTypeConfiguration<Holder>.Configure(EntityTypeBuilder<Holder> builder)
        {
             builder.ToTable("holder", "soc");
             builder.HasKey(x => x.Id);
             builder.Property(x => x.Name).HasColumnName("name");
             builder.Property(x => x.LastName).HasColumnName("lastname");
             builder.Property(x => x.Address).HasColumnName("address");
             builder.Property(x => x.CorporatEmail).HasColumnName("corporatemail");
             builder.Property(x => x.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
             builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
