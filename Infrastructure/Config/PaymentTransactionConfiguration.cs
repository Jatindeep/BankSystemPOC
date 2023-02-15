using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    internal sealed class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("PaymentTransaction");
            builder.HasKey(paymentTransaction => paymentTransaction.Id);
            builder.Property(paymentTransaction => paymentTransaction.AccountId).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.SenderName).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.ReceiverName).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.ReceiverAccountNo).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.Amount).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.CreatedOn).IsRequired();
            builder.Property(paymentTransaction => paymentTransaction.IsCompleted).IsRequired();

            builder.HasOne(paymentTransaction => paymentTransaction.Account)
                    .WithMany(account => account.PaymentTransactions)
                    .HasForeignKey(paymentTransaction => paymentTransaction.AccountId);

        }
    }
}
