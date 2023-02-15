using Application.Interfaces.Command;
using Domain.Entities;

namespace Infrastructure.Repositories.Command
{
    public sealed class AccountCommandRepository : IAccountCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Insert Account
        /// </summary>
        /// <param name="account"></param>
        public void InsertAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update Account
        /// </summary>
        /// <param name="account"></param>
        public void UpdateAccount(Account account)
        {
            var existingAccount = _dbContext.Accounts.SingleOrDefault(b => b.Id == account.Id);
            if (existingAccount != null)
            {
                _dbContext.Entry(account).CurrentValues.SetValues(existingAccount);
                _dbContext.SaveChanges();
            }
        }
    }
}
