using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review.API.Exceptions
{
    public class InvalidRequestData : Exception
    {
        public InvalidRequestData(string message) : base(message) { }
    }
}
