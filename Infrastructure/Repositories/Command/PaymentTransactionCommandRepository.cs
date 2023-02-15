using Application.Interfaces.Command;
using Domain.Entities;

namespace Infrastructure.Repositories.Command
{
    public sealed class PaymentTransactionCommandRepository : IPaymentTransactionCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentTransactionCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Insert PaymentTransaction
        /// </summary>
        /// <param name="paymentTransaction"></param>
        public void InsertPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            _dbContext.PaymentTransactions.Add(paymentTransaction);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update PaymentTransaction
        /// </summary>
        /// <param name="paymentTransaction"></param>
        public void UpdatePaymentTransaction(PaymentTransaction paymentTransaction)
        {
            var existingPaymentTransaction = _dbContext.PaymentTransactions.SingleOrDefault(b => b.Id == paymentTransaction.Id);
            if (existingPaymentTransaction != null)
            {
                _dbContext.Entry(paymentTransaction).CurrentValues.SetValues(existingPaymentTransaction);
                _dbContext.SaveChanges();
            }
        }
    }
}
