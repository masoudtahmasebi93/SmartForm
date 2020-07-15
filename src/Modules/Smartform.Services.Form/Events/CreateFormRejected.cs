using System;
using SmartForm.Common.Events;

namespace SmartForm.Services.Form.Events
{
    public class CreateFormRejected : IRejectedEvent
    {
        protected CreateFormRejected()
        {
        }

        public CreateFormRejected(Guid id,
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