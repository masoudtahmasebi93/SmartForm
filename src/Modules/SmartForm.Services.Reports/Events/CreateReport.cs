using System;
using SmartForm.Common.Commands;

namespace SmartForm.Services.Activities.Events
{
    public class CreateReport : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UserId { get; set; }
        //Guid? IAuthenticatedCommand.UserId { get ; set; }
    }
}