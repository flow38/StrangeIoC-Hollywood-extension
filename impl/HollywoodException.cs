using System;
using falcy.strange.extensions.hollywood.api;

namespace falcy.strange.extensions.hollywood.impl
{
    public class HollywoodException : Exception
    {
        public HollywoodExceptionType type { get; set; }

        public HollywoodException() : base()
		{
        }

        /// Constructs a MediationException with a message and MediationExceptionType
        public HollywoodException(string message, HollywoodExceptionType exceptionType) : base(message)
		{
            type = exceptionType;
        }
    }
}