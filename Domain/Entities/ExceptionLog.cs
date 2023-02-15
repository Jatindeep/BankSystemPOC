using Domain.Entities.Base;

namespace Domain.Entities
{
    /// <summary>
    /// ExceptionLog data
    /// </summary>
    public class ExceptionLog : BaseEntity
    {
        public string Message { get; set; } = string.Empty;
        public string Stacktrace { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
