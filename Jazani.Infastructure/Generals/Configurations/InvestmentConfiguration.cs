using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Generals.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        void IEntityTypeConfiguration<Investment>.Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AmountInvestd).HasColumnName("amountinvestd");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.HolderId).HasColumnName("holderid");
            builder.Property(x => x.InvestmentConceptId).HasColumnName("investmentconceptid");
            builder.Property(x => x.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(x => x.CurrencyTypeId).HasColumnName("currencytypeid");
            builder.Property(x => x.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(x => x.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(x => x.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.MonthName).HasColumnName("monthname");
            builder.Property(x => x.DeclaredTypeId).HasColumnName("declaredtypeid");
            builder.Property(x => x.DocumentId).HasColumnName("documentid");

            // Definir las relaciones de la claves foraneas
            builder.HasOne(o => o.Holder)
                .WithMany(m => m.Investments )
                .HasForeignKey(fk => fk.HolderId);

            builder.HasOne(o => o.InvestmentConcept)
                .WithMany(m => m.Investments)
                .HasForeignKey(fk => fk.InvestmentConceptId);

            builder.HasOne(o => o.InvestmentType)
                 .WithMany(m => m.Investments)
                 .HasForeignKey(fk => fk.InvestmentTypeId);

            builder.HasOne(o => o.MiningConcession)
                 .WithMany(m => m.Investments)
                 .HasForeignKey(fk => fk.MiningConcessionId);

            builder.HasOne(o => o.MeasureUnit)
                 .WithMany(m => m.Investments)
                 .HasForeignKey(fk => fk.MeasureUnitId);

            builder.HasOne(o => o.PeriodType)
                .WithMany(m => m.Investments)
                .HasForeignKey(fk => fk.PeriodTypeId);

        }
    }
}
