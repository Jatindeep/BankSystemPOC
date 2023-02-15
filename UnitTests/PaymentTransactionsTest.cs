using Domain.Entities;
using Infrastructure.Repositories.Query;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    [TestClass]
    public class PaymentTransactionsTest
    {
        /// <summary>
        /// Add paymentTransaction Test
        /// </summary>
        [TestMethod]
        public void AddPaymentTransactionTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            Guid newTransactionId = Guid.NewGuid();
            AddPaymentTransaction(newTransactionId);

            using (var context = new ApplicationDbContext(options))
            {
                var _ptqr = new PaymentTransactionQueryRepository(context);
                var paymentTransaction = _ptqr.GetById(newTransactionId);

                Assert.IsTrue(paymentTransaction != null);
            }
        }

        /// <summary>
        /// Get All PaymentTransaction Test
        /// </summary>
        [TestMethod]
        public void GetAllPaymentTransactionsTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            AddPaymentTransaction(Guid.NewGuid());

            using (var context = new ApplicationDbContext(options))
            {
                var _ptqr = new PaymentTransactionQueryRepository(context);
                var paymentTransactions = _ptqr.GetAllPaymentTransactions();

                Assert.IsTrue(paymentTransactions.Any());
            }
        }

        /// <summary>
        /// Add PaymentTransaction
        /// </summary>
        /// <param name="transactionId"></param>
        private void AddPaymentTransaction(Guid transactionId)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BankSystemInMemory")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.PaymentTransactions.Add(new PaymentTransaction
                {
                    Id = transactionId,
                    AccountId = Guid.NewGuid(),
                    IsCompleted = true,
                    SenderName = "Sender",
                    ReceiverName = "Receiver",
                    ReceiverAccountNo = "4321",
                    CreatedOn = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                });
                context.SaveChanges();
            }
        }
    }
}