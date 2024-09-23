using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReclamacoes.Application.DTOs
{
    public class ReclamacaoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Tipo de Pessoa é obrigatório")]
        [DisplayName("Tipo Pessoa")]
        public string TipoPessoa { get; set; } // Exibição como string

        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome do Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Idade ou Tempo de Constituição é obrigatório")]
        [Range(0, 150, ErrorMessage = "A Idade/Tempo deve ser válida")]
        [DisplayName("Idade/Tempo de Constituição")]
        public int IdadeOuTempoConstituicao { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O Telefone deve ter 11 dígitos")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public int ProdutoId { get; set; } 

        [Required(ErrorMessage = "O Produto é obrigatório")]
        [DisplayName("Produto Reclamado")]
        public string ProdutoNome { get; set; } 

        [Required(ErrorMessage = "A Data de Reclamação é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayName("Data da Reclamação")]
        public DateTime DataReclamacao { get; set; }

        [Required(ErrorMessage = "A Data de Ocorrência é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayName("Data da Ocorrência")]
        public DateTime DataOcorrencia { get; set; }

        [Required(ErrorMessage = "O Valor Reclamado é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor Reclamado")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MaxLength(400)]
        [DisplayName("Descrição da Reclamação")]
        public string Descricao { get; set; }
    }
}
