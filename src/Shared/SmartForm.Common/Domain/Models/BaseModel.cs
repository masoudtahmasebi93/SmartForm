using System;

namespace SmartForm.Common.Domain.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}