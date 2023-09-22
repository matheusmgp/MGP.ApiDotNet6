﻿using MGP.ApiDotNet6.Domain.Validations;

namespace MGP.ApiDotNet6.Domain.Entities
{
    public sealed class Person : BaseEntity
    {
        
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string document,string name,string phone)
        {
            Validate(document, name, phone);
            Purchases = new List<Purchase>();
        }
        public Person(int id, string document, string name, string phone)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validate(document, name, phone);
            Purchases = new List<Purchase>();
        }

        private void Validate(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone deve ser informado");
            Name = name; 
            Phone = phone;  
            Document = document;
        }
    }
}