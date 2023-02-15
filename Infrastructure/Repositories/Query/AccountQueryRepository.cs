using Application.Interfaces.Query;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.Repositories.Query
{
    public sealed class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountQueryRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Get Account By Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>
        public Account GetById(Guid accountId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account == null) throw new AccountNotFoundException(accountId);

            return account;
        }

        /// <summary>
        /// Get Account by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Account GetByUserId(Guid userId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.UserId == userId);
            if (account == null) throw new Exception();

            return account;
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        /// <summary>
        /// Get Account Balance by AccountId
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public decimal GetAccountBalanceById(Guid accountId)
        {
            var account = _dbContext.Accounts.SingleOrDefault(x => x.Id == accountId);
            return account != null ? account.Balance : 0;
        }

        /// <summary>
        /// Get Account Balance by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetAccountBalanceByUserId(Guid userId)
        {
            var account = _dbContext.Accounts.SingleOrDefault(x => x.UserId == userId);
            return account != null ? account.Balance : 0;
        }
    }
}
