using AppReclamacoes.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppReclamacoes.Application.Interfaces
{
    public interface IReclamacaoService
    {
        Task<IEnumerable<ReclamacaoDTO>> GetReclamacoes();
        Task<ReclamacaoDTO> GetById(int? id);

        Task<ReclamacaoDTO> GetReclamacaoProduto(int? id);
        Task Add(ReclamacaoDTO reclamacaoDTO);
        Task Update(ReclamacaoDTO reclamacaoDto);
        Task Remove(int? id);
    }
}
