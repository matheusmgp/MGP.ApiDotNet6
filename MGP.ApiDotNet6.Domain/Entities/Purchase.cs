using MGP.ApiDotNet6.Domain.Validations;

namespace MGP.ApiDotNet6.Domain.Entities
{
    public sealed class Purchase : BaseEntity
    {
       
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; set; }


        public Purchase(int productId, int personId)
        {
            Validate(productId, personId);
        }
        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "ID deve ser informado");
            Id = id;
            Validate(productId, personId);
        }
        private void Validate(int productId, int personId)
        {
            DomainValidationException.When(ProductId < 0, "ID Produto deve ser informado");
            DomainValidationException.When(PersonId < 0, "ID Pessoa deve ser informado");           
            ProductId = ProductId;
            PersonId = PersonId;
            Date = DateTime.Now;
        }
    }
}
