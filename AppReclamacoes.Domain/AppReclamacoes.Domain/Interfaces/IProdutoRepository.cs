using System;
using AppReclamacoes.Domain.Entities;

namespace AppReclamacoes.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetByIdAsync(int? id);
        Task<Produto> CreateAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task<Produto> RemoveAsync(Produto produto);
    }
}
