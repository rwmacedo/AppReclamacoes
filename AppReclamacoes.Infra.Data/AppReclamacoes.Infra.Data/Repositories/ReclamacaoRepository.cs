using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Domain.Interfaces;
using AppReclamacoes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppReclamacoes.Infra.Data.Repositories
{
    public class ReclamacaoRepository : IReclamacaoRepository
    {
        private readonly ApplicationDbContext _context;
        public ReclamacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reclamacao> CreateAsync(Reclamacao reclamacao)
        {
            _context.Add(reclamacao);
            await _context.SaveChangesAsync();
            return reclamacao;
        }
        public async Task<Reclamacao> GetReclamacaoProdutoAsync(int id)
{
    return await _context.Reclamacoes.Include(p => p.Produto)
                                     .FirstOrDefaultAsync(r => r.Id == id);
}


        public async Task<Reclamacao> GetByIdAsync(int? id)
        {
            return await _context.Reclamacoes
                .Include(r => r.Produto) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reclamacao>> GetReclamacoesAsync()
        {
            return await _context.Reclamacoes
                .Include(r => r.Produto) 
                .ToListAsync();
        }

        public async Task<Reclamacao> RemoveAsync(Reclamacao reclamacao)
        {
            _context.Remove(reclamacao);
            await _context.SaveChangesAsync();
            return reclamacao;
        }

        public async Task<Reclamacao> UpdateAsync(Reclamacao reclamacao)
        {
            _context.Update(reclamacao);
            await _context.SaveChangesAsync();
            return reclamacao;
        }
    }
}
