using Application.Interfaces.Query;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.Repositories.Query
{
    public sealed class PaymentTransactionQueryRepository : IPaymentTransactionQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentTransactionQueryRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public List<PaymentTransaction> GetAllPaymentTransactions()
        {
            return _dbContext.PaymentTransactions.ToList();
        }

        public List<PaymentTransaction> GetAllPaymentTransactionsByAccountId(Guid acountId)
        {
            return _dbContext.PaymentTransactions.Where(x => x.AccountId == acountId).ToList();
        }

        public PaymentTransaction GetById(Guid paymentTransactionId)
        {
            var paymentTransaction = _dbContext.PaymentTransactions.FirstOrDefault(x => x.Id == paymentTransactionId);
            if (paymentTransaction == null) throw new PaymentTransactionNotFoundException(paymentTransactionId);

            return paymentTransaction;
        }
    }
}
