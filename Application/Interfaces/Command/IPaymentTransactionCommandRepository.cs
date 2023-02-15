using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IPaymentTransactionCommandRepository
    {
        /// <summary>
        /// Insert Payment Transaction
        /// </summary>
        /// <param name="paymentTransaction"></param>
        void InsertPaymentTransaction(PaymentTransaction paymentTransaction);

        /// <summary>
        /// Update Payment Transaction
        /// </summary>
        /// <param name="paymentTransaction"></param>
        void UpdatePaymentTransaction(PaymentTransaction paymentTransaction);
    }
}
