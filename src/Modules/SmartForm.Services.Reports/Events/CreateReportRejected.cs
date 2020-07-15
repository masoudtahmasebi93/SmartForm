using System;
using SmartForm.Common.Events;

namespace SmartForm.Services.Activities
{
    public class CreateReportRejected : IRejectedEvent
    {
        protected CreateReportRejected()
        {
        }

        public CreateReportRejected(Guid id,
            string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }

        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}