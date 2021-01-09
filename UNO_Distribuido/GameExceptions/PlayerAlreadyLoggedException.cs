using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameExceptions
{
    public class PlayerAlreadyLoggedException : Exception
    {
        public PlayerAlreadyLoggedException() : base("El usuario ya se encuentra logeado")
        {
        }

        public PlayerAlreadyLoggedException(string message) : base(message)
        {
        }

        public PlayerAlreadyLoggedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
