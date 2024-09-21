using System;
using System.Text.RegularExpressions;

namespace AppReclamacoes.Domain.Entities
{
    public sealed class Reclamacao
    {
        public int Id { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; } = TipoPessoa.PessoaFisica;
        public string CpfCnpj { get; private set; }
        public string Nome { get; private set; }
        public int IdadeOuTempoConstituicao { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public ProdutoReclamado Produto { get; private set; }
        public DateTime DataReclamacao { get; private set; }
        public DateTime DataOcorrencia { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }

        // Construtor sem ID (novo objeto)
        public Reclamacao(TipoPessoa tipoPessoa, string cpfCnpj, string nome, int idadeOuTempoConstituicao, string telefone, string email,
             ProdutoReclamado produto, DateTime dataReclamacao, DateTime dataOcorrencia, decimal valor, string descricao)
        {
            ValidateDomain(tipoPessoa, cpfCnpj, nome, idadeOuTempoConstituicao, telefone, email,
             produto, dataReclamacao, dataOcorrencia, valor, descricao);
        }

        // Construtor com ID (atualização)
        public Reclamacao(int id, TipoPessoa tipoPessoa, string cpfCnpj, string nome, int idadeOuTempoConstituicao, string telefone, string email,
         ProdutoReclamado produto, DateTime dataReclamacao, DateTime dataOcorrencia, decimal valor, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;
            ValidateDomain(tipoPessoa, cpfCnpj, nome, idadeOuTempoConstituicao, telefone, email,
             produto, dataReclamacao, dataOcorrencia, valor, descricao);
        }

        // Método de atualização
        public void Update(TipoPessoa tipoPessoa, string cpfCnpj, string nome, int idadeOuTempoConstituicao, string telefone, string email,
           ProdutoReclamado produto, DateTime dataReclamacao, DateTime dataOcorrencia, decimal valor, string descricao)
        {
            ValidateDomain(tipoPessoa, cpfCnpj, nome, idadeOuTempoConstituicao, telefone, email,
             produto, dataReclamacao, dataOcorrencia, valor, descricao);
        }

        // Validação do domínio
        private void ValidateDomain(TipoPessoa tipoPessoa, string cpfCnpj, string nome, int idadeOuTempoConstituicao, string telefone, string email,
             ProdutoReclamado produto, DateTime dataReclamacao, DateTime dataOcorrencia, decimal valor, string descricao)
        {
            // Validações de TipoPessoa
            DomainExceptionValidation.When(tipoPessoa != TipoPessoa.PessoaFisica && tipoPessoa != TipoPessoa.PessoaJuridica, "Tipo de pessoa inválido. Deve ser 1 (Pessoa Física) ou 2 (Pessoa Jurídica).");

            // Validações de CpfCnpj
            if (tipoPessoa == TipoPessoa.PessoaFisica)
            {
                DomainExceptionValidation.When(cpfCnpj.Length != 11, "CPF inválido. Deve conter 11 caracteres.");
            }
            else if (tipoPessoa == TipoPessoa.PessoaJuridica)
            {
                DomainExceptionValidation.When(cpfCnpj.Length != 14, "CNPJ inválido. Deve conter 14 caracteres.");
            }

            // Validações de Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 2, "Nome inválido. Mínimo de 2 caracteres.");

            // Validações de Telefone (11 números: 2 para o DDD e 9 para o telefone)
            DomainExceptionValidation.When(telefone.Length != 11, "Telefone inválido. Deve conter 11 dígitos (2 para DDD e 9 para o número de telefone).");

            // Validação de e-mail (básica)
            DomainExceptionValidation.When(!IsValidEmail(email), "E-mail inválido.");

            // Validações de Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é obrigatória.");
            DomainExceptionValidation.When(descricao.Length < 10, "Descrição inválida. Mínimo de 10 caracteres.");

            // Validações de Datas (não podem ser futuras)
            DomainExceptionValidation.When(dataReclamacao > DateTime.Now, "Data de reclamação inválida. Não pode ser uma data futura.");
            DomainExceptionValidation.When(dataOcorrencia > DateTime.Now, "Data de ocorrência inválida. Não pode ser uma data futura.");

            // Atribuição das propriedades após validação
            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
            Nome = nome;
            IdadeOuTempoConstituicao = idadeOuTempoConstituicao;
            Telefone = telefone;
            Email = email;
            Produto = produto;
            DataReclamacao = dataReclamacao;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
            Descricao = descricao;
        }

        // Método auxiliar para validar e-mail
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Validação básica de e-mail
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }
    }

    // Enumeração para TipoPessoa
    public enum TipoPessoa
    {
        PessoaFisica = 1,
        PessoaJuridica = 2
    }

    // Enumeração para Produto Reclamado
    public enum ProdutoReclamado
    {
        ContaDeposito,
        Cambio,
        Habitacao,
        Penhor,
        AcoesOnline,
        Seguro,
        CartaoCredito,
        FundosInvestimento,
        Consignado
    }
}

