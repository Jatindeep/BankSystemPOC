using Application.Interfaces.Command;
using Domain.Entities;

namespace Infrastructure.Repositories.Command
{
    public sealed class LoggerCommandRepository : ILoggerCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoggerCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Add Event Log
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="existingValue"></param>
        /// <param name="newValue"></param>
        /// <param name="createdBy"></param>
        public void AddEventLog(string entity, string existingValue, string newValue, string createdBy)
        {
            EventLog eventLog = new()
            {
                Entity = entity,
                ExistingValue = existingValue,
                NewValue = newValue,
                CreatedBy = createdBy
            };
            _dbContext.EventLogs.Add(eventLog);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Add Exception Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stacktrace"></param>
        /// <param name="createdBy"></param>
        public void AddExceptionLog(string message, string stacktrace, string createdBy)
        {
            ExceptionLog exceptionLog = new()
            {
                Message = message,
                Stacktrace = stacktrace,
                CreatedBy = createdBy
            };
            _dbContext.ExceptionLogs.Add(exceptionLog);
            _dbContext.SaveChanges();
        }
    }
}
