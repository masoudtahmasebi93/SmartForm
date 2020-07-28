using System;

namespace SmartForm.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid? UserId { get; set; }
    }
}