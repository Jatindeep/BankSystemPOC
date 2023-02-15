using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class PaymentTransactionNotFoundException : NotFoundException
    {
        public PaymentTransactionNotFoundException(Guid paymentTransactionId)
            : base($"The Payment Transaction with the Id {paymentTransactionId} was not found.")
        {
        }
    }
}
