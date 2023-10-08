using Jazani.Domain.Generals.Models;
using Jazani.Infastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infastructure.Generals.Configurations
{
    public class PayConfiguration : IEntityTypeConfiguration<Pay>
    {
        public void Configure(EntityTypeBuilder<Pay> builder)
        {
            builder.ToTable("pay", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Year).HasColumnName("year");
            builder.Property(x => x.ReceiptNumber).HasColumnName("receiptnumber");
            builder.Property(x => x.ReceiptDate).HasColumnName("receiptdate");
            builder.Property(x => x.IndividualCost).HasColumnName("individualcost");
            builder.Property(x => x.AmountPaid).HasColumnName("amountpaid");
            builder.Property(x => x.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(x => x.FinancialentityId).HasColumnName("financialentityid");
            builder.Property(x => x.CurrencyTypeId).HasColumnName("currencytypeid");
            builder.Property(x => x.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(x => x.ConceptId).HasColumnName("conceptid");
            builder.Property(x => x.ExerciseId).HasColumnName("exerciseid");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.AvailableArea).HasColumnName("availablearea");


            builder.HasOne(o => o.Financialentity)
                .WithMany(many => many.Pays)
                .HasForeignKey(fk => fk.FinancialentityId);
        }
    }
}
