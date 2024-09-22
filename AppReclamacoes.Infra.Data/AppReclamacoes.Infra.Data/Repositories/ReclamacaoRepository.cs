using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Domain.Interfaces;
using AppReclamacoes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ReclamacaoRepository : IReclamacaoRepository
    {
        private readonly ApplicationDbContext _reclamacaoContext;
        public ReclamacaoRepository(ApplicationDbContext context)
        {
            _reclamacaoContext = context;
        }

        public async Task<Reclamacao> CreateAsync(Reclamacao reclamacao)
        {
            _reclamacaoContext.Add(reclamacao);
            await _reclamacaoContext.SaveChangesAsync();
            return reclamacao;
        }

        public async Task<Reclamacao> GetByIdAsync(int? id)
        {
            return await _reclamacaoContext.Reclamacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Reclamacao>> GetReclamacoesAsync()
        {
            return await _reclamacaoContext.Reclamacoes.ToListAsync();
        }

        public async Task<Reclamacao> RemoveAsync(Reclamacao reclamacao)
        {
            _reclamacaoContext.Remove(reclamacao);
            await _reclamacaoContext.SaveChangesAsync();
            return reclamacao;
        }

        public async Task<Reclamacao> UpdateAsync(Reclamacao reclamacao)
        {
            _reclamacaoContext.Update(reclamacao);
            await _reclamacaoContext.SaveChangesAsync();
            return reclamacao;
        }
    }
}
