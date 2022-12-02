using System;

namespace Domain.Abstraction
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
