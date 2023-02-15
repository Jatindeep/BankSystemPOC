using Domain.Entities.Base;

namespace Domain.Entities
{
    /// <summary>
    /// EventLog Data
    /// </summary>
    public class EventLog : BaseEntity
    {
        public string Entity { get; set; } = string.Empty;
        public string ExistingValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
