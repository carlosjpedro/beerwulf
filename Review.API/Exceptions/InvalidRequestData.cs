using System;

namespace Review.API.Exceptions
{
    public class InvalidRequestData : Exception
    {
        public InvalidRequestData(string message) : base(message) { }
    }

    public class ProductNotFound : Exception
    {
        public ProductNotFound(int productId) : base($"Product with id:{productId} not found.") { }
    }
}
