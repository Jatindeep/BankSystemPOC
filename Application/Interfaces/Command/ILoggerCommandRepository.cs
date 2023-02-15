namespace Application.Interfaces.Command
{
    public interface ILoggerCommandRepository
    {
        /// <summary>
        /// Add Exception Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stacktrace"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        void AddExceptionLog(string message, string stacktrace, string createdBy);

        /// <summary>
        /// Add Event Log
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="existingValue"></param>
        /// <param name="oldValue"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        void AddEventLog(string entity, string existingValue, string newValue, string createdBy);
    }
}
