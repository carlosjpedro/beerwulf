using System;

namespace Review.API.Exceptions
{
    public class InvalidRequestData : Exception
    {
        public InvalidRequestData(string message) : base(message) { }
    }
}
