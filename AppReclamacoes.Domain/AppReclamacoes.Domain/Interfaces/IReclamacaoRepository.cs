using System;
using AppReclamacoes.Domain.Entities;

namespace AppReclamacoes.Domain.interface 
{
    public interface IReclamacaoRepository
    {
        Task<IEnumerable<Reclamacao>> GetReclamacoesAsync();
        Task<Reclamacao> GetByIdAsync(int? id);

        Task<Reclamacao> CreateAsync(Reclamacao reclamacao);
        Task<Reclamacao> UpdateAsync(Reclamacao reclamacao);
        Task<Reclamacao> RemoveAsync(Reclamacao reclamacao);

    }
    
}
