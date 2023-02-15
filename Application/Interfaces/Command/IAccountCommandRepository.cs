using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IAccountCommandRepository
    {
        /// <summary>
        /// Insert Account
        /// </summary>
        /// <param name="account"></param>
        void InsertAccount(Account account);

        /// <summary>
        /// Update Account
        /// </summary>
        /// <param name="account"></param>
        void UpdateAccount(Account account);
    }
}
