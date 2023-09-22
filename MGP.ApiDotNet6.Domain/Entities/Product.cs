using MGP.ApiDotNet6.Domain.Validations;

namespace MGP.ApiDotNet6.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
      
        public string Name { get; private set; }
        public string CodErp { get; private set; } 
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codErp, decimal price)
        {
            Validate(name, codErp, price);
            Purchases = new List<Purchase>();
        }
        public Product(int id , string name, string codErp, decimal price)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validate(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        private void Validate(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código erp deve ser informado");
            DomainValidationException.When(price < 0 , "Preço deve ser informado");
            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
