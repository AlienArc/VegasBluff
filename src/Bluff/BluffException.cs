using System;
using System.Collections.Generic;
using System.Text;

namespace Bluff
{
    public class BluffException : Exception
    {
        public BluffException(string message) : base(message)
        {
        }

        public BluffException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
