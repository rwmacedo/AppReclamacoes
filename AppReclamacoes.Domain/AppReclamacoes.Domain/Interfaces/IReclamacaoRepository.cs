using System;
using AppReclamacoes.Domain.Entities;


namespace AppReclamacoes.Domain.Interfaces
{
    public interface IReclamacaoRepository
    {
        Task<IEnumerable<Reclamacao>> GetReclamacoesAsync();
        
        Task<Reclamacao> GetReclamacaoProdutoAsync(int id);

        Task<Reclamacao> GetByIdAsync(int? id);
        Task<Reclamacao> CreateAsync(Reclamacao reclamacao);
        Task<Reclamacao> UpdateAsync(Reclamacao reclamacao);
        Task<Reclamacao> RemoveAsync(Reclamacao reclamacao);
    }
}