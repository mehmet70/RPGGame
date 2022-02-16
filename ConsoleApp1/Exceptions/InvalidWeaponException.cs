using System;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
        }

        public InvalidWeaponException(string message) : base(message)
        {
        }

        public InvalidWeaponException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidWeaponException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}