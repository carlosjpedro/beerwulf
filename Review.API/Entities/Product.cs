using System;
using System.ComponentModel.DataAnnotations;

namespace Review.API.Entities
{
    public class Product
    {
        private Product() { }
        [Key]
        public int ProductId { get; private set; }
        public string Name { get; private set; }

        public Product(int productId, string name)
        {
            ProductId = productId;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductId == product.ProductId &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, Name);
        }
    }
}
