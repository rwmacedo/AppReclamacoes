using AppReclamacoes.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppReclamacoes.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutosAsync();
        Task<ProdutoDTO> GetByIdAsync(int? id);
        Task Add(ProdutoDTO produtoDto);
        Task UpdateAsync(ProdutoDTO produtoDto);
        Task RemoveAsync(int? id);
    }
}
