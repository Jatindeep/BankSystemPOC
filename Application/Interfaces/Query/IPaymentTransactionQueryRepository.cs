using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IPaymentTransactionQueryRepository
    {
        PaymentTransaction GetById(Guid paymentTransactionId);
        List<PaymentTransaction> GetAllPaymentTransactionsByAccountId(Guid acountId);
        List<PaymentTransaction> GetAllPaymentTransactions();
    }
}
