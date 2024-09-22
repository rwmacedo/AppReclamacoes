using System;
using AppReclamacoes.Domain.Validation;

namespace AppReclamacoes.Domain.Entities
{
    public sealed class Produto
    {
        public int Id { get; private set; }
        public string NomeProduto { get; private set; }

        // Construtor sem ID (para novos produtos)
        public Produto(string nomeProduto)
        {
            NomeProduto = nomeProduto ?? throw new ArgumentNullException(nameof(nomeProduto));
            ValidateDomain(nomeProduto);
        }

        // Construtor com ID (para atualização de produtos)
        public Produto(int id, string nomeProduto)
        {
            NomeProduto = nomeProduto ?? throw new ArgumentNullException(nameof(nomeProduto));
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;
            ValidateDomain(nomeProduto);
        }

        // Método de atualização
        public void Update(string nomeProduto)
        {
            ValidateDomain(nomeProduto);
        }

        // Validação do domínio
        private void ValidateDomain(string nomeProduto)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeProduto), "Nome do produto é obrigatório.");
            DomainExceptionValidation.When(nomeProduto.Length < 3, "Nome do produto deve ter no mínimo 3 caracteres.");

            NomeProduto = nomeProduto;
        }
    }
}
