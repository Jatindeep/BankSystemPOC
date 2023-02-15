using Domain.Entities;
using Infrastructure.Repositories.Query;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    [TestClass]
    public class AccountsTest
    {
        /// <summary>
        /// Add Account Test
        /// </summary>
        [TestMethod]
        public void AddAccountTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            Guid newAccountId = Guid.NewGuid();
            AddAccountData(newAccountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueryRepository(context);
                var account = _aqr.GetById(newAccountId);

                Assert.IsTrue(account != null);
            }
        }

        /// <summary>
        /// Get All Accounts Test
        /// </summary>
        [TestMethod]
        public void GetAllAccountsTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            AddAccountData(Guid.NewGuid());

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueryRepository(context);
                var accounts = _aqr.GetAllAccounts();

                Assert.IsTrue(accounts.Any());
            }
        }


        /// <summary>
        /// Add Account
        /// </summary>
        /// <param name="accountId"></param>
        private void AddAccountData(Guid accountId)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Accounts.Add(new Account
                {
                    Id = accountId,
                    AccountNumber = "1234",
                    IsActive = true,
                    Balance = 100,
                    UserId = Guid.NewGuid(),
                });
                context.SaveChanges();
            }
        }
    }
}