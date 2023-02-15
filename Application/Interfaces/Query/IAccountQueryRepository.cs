using Domain.Entities;

namespace Application.Interfaces.Query
{
    public interface IAccountQueryRepository
    {
        /// <summary>
        /// Get Account by Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Account GetById(Guid accountId);

        /// <summary>
        /// Get Account by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Account GetByUserId(Guid userId);

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        List<Account> GetAllAccounts();

        /// <summary>
        /// Get Account Balance By AccountId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        decimal GetAccountBalanceById(Guid accountId);

        /// <summary>
        /// Get Account Balance By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        decimal GetAccountBalanceByUserId(Guid userId);
    }
}
