using System;

namespace SmartForm.Common.Exceptions
{
    public class SmartFormException : Exception
    {
        public SmartFormException()
        {
        }

        public SmartFormException(string code)
        {
            Code = code;
        }

        public SmartFormException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public SmartFormException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public SmartFormException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public SmartFormException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

        public string Code { get; }
    }
}