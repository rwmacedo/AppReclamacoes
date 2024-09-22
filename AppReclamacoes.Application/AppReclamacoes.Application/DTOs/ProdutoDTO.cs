using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppReclamacoes.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Produto é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("NomeProduto")]
        public string NomeProduto { get; set; }= string.Empty;
    }
}
