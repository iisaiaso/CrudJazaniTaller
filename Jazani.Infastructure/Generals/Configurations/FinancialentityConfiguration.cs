using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jazani.Infastructure.Generals.Configurations
{
    public class FinancialentityConfiguration : IEntityTypeConfiguration<Financialentity>
    {
        void IEntityTypeConfiguration<Financialentity>.Configure(EntityTypeBuilder<Financialentity> builder)
        {
            builder.ToTable("financialentity", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Ruc).HasColumnName("ruc");
            builder.Property(x => x.Address).HasColumnName("address");
            builder.Property(x => x.PhoneNumber).HasColumnName("phonenumber");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");


            
        }
    }
}
