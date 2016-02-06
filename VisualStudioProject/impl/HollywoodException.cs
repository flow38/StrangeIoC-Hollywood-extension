using strange.extensions.hollywood.api;
using System;

namespace strange.extensions.hollywood.impl
{
   public class HollywoodException : Exception
    {
        public HollywoodExceptionType Type { get; set; }

        /// Constructs a HollywoodException with a message and HollywoodExceptionType
		public HollywoodException(string message, HollywoodExceptionType type) : base(message)
		{
            Type = type;
        }
    }
}
