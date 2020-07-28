using System;

namespace SmartForm.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid? UserId { get; }
    }
}