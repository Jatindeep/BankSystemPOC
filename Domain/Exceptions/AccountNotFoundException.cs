using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException(Guid accountId)
            : base($"The account with the Id {accountId} was not found.")
        {
        }
    }
}
