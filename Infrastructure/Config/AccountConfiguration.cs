using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(account => account.Id);
            builder.Property(account => account.AccountNumber).IsRequired();
            builder.Property(account => account.Balance).IsRequired();
            builder.Property(account => account.IsActive).HasDefaultValue(true);
            builder.Property(account => account.UserId).IsRequired();

            builder.HasMany(account => account.PaymentTransactions)
                    .WithOne(paymentTransaction => paymentTransaction.Account)
                    .HasForeignKey(paymentTransaction => paymentTransaction.AccountId);
        }
    }
}
