using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameExceptions
{
    public class PlayerVerificationException : Exception
    {
        public PlayerVerificationException() : base("El jugador no se ha verificado")
        {
        }

        public PlayerVerificationException(string message) : base(message)
        {
        }

        public PlayerVerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerVerificationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
