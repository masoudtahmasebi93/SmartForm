using System;
using SmartForm.Common.Events;

namespace SmartForm.Services.Activities
{
    public class ReportCreated : IAuthenticatedEvent
    {
        protected ReportCreated()
        {
        }

        public ReportCreated(Guid id, Guid userId,
            string category, string name,
            string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }
        public Guid UserId { get; }
    }
}