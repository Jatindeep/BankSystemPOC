using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Domain.Entities;
using System.Transactions;

namespace Presentation.Services
{
    public class BankingService
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IPaymentTransactionCommandRepository _paymentTransactionCommandRepository;
        private readonly IPaymentTransactionQueryRepository _paymentTransactionQueryRepository;
        public BankingService(IAccountCommandRepository accountCommandRepository, IAccountQueryRepository accountQueryRepository,
            IPaymentTransactionCommandRepository paymentTransactionCommandRepository, IPaymentTransactionQueryRepository paymentTransactionQueryRepository)
        {
            _accountCommandRepository = accountCommandRepository;
            _accountQueryRepository = accountQueryRepository;
            _paymentTransactionCommandRepository = paymentTransactionCommandRepository;
            _paymentTransactionQueryRepository = paymentTransactionQueryRepository;
        }

        /// <summary>
        /// Create a new Account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
        /// <param name="userId"></param>
        /// <exception cref="Exception"></exception>
        public void CreateAccount(string accountNumber, decimal balance, Guid userId)
        {
            try
            {
                Account account = new()
                {
                    Id = Guid.NewGuid(),
                    AccountNumber = accountNumber,
                    Balance = balance,
                    IsActive = true,
                    UserId = userId
                };
                _accountCommandRepository.InsertAccount(account);
            }
            catch (Exception ex)
            {
                throw new Exception("Account Balance Error", ex);
            }
        }
        
        /// <summary>
        /// Retrieve Account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Account GetAccountByUserId(Guid userId)
        {
            try
            {
                return _accountQueryRepository.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Account Error", ex);
            }
        }


        /// <summary>
        /// Transfer Funds by creating a new PaymentTranscation
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="receiverName"></param>
        /// <param name="receiverAccountNo"></param>
        /// <param name="senderName"></param>
        /// <returns></returns>
        public string TransferAmount(Guid userId, decimal amount, string receiverName, string receiverAccountNo, string senderName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var account = _accountQueryRepository.GetByUserId(userId);
                if (account != null)
                {
                    if (account.Balance < amount)
                    {
                        throw new Exception("Cannot transfer amount greater than available balance.");
                    }
                    Guid newTransctionId = Guid.NewGuid();
                    PaymentTransaction paymentTransaction = new()
                    {
                        Id = newTransctionId,
                        Amount = amount,
                        AccountId = account.Id,
                        IsCompleted = true,
                        CreatedOn = DateTime.Now,
                        SenderName = senderName,
                        ReceiverAccountNo = receiverAccountNo,
                        ReceiverName = receiverName,
                    };
                    _paymentTransactionCommandRepository.InsertPaymentTransaction(paymentTransaction);
                    account.Balance -= amount;
                    _accountCommandRepository.UpdateAccount(account);
                    scope.Complete();
                    return newTransctionId.ToString();
                }
                else
                {
                    throw new Exception("Account Not Found.");
                }
            }
        }

        /// <summary>
        /// Retieve PaymentTransaction by transactionId
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public PaymentTransaction GetTransactionById(Guid transactionId)
        {
            try
            {
                return _paymentTransactionQueryRepository.GetById(transactionId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Get all PaymentTransactions for a given userz
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PaymentTransaction> GetAllUserTransactions(Guid userId)
        {
            try
            {
                var account = _accountQueryRepository.GetByUserId(userId);
                if (account != null)
                {
                    return _paymentTransactionQueryRepository.GetAllPaymentTransactionsByAccountId(account.Id).OrderByDescending(x => x.CreatedOn).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }

}
