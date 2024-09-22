using AutoMapper;
using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppReclamacoes.Application.Services
{
    public class ReclamacaoService : IReclamacaoService
    {
        private IReclamacaoRepository _ReclamacaoRepository;

        private readonly IMapper _mapper;
        public ReclamacaoService(IMapper mapper, IReclamacaoRepository ReclamacaoRepository)
        {
            _ReclamacaoRepository = ReclamacaoRepository ??
                 throw new ArgumentNullException(nameof(ReclamacaoRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ReclamacaoDTO>> GetReclamacoes()
        {
            var ReclamacaoEntity = await _ReclamacaoRepository.GetReclamacoesAsync();
            return _mapper.Map<IEnumerable<ReclamacaoDTO>>(ReclamacaoEntity);
        }

        public async Task<ReclamacaoDTO> GetById(int? id)
        {
            var ReclamacaoEntity = await _ReclamacaoRepository.GetByIdAsync(id);
            return _mapper.Map<ReclamacaoDTO>(ReclamacaoEntity);
        }

public async Task<ReclamacaoDTO> GetReclamacaoProduto(int? id)
{
    var idValue = id ?? 0; // Converter int? para int
    var ReclamacaoEntity = await _ReclamacaoRepository.GetReclamacaoProdutoAsync(idValue);
    return _mapper.Map<ReclamacaoDTO>(ReclamacaoEntity);
}

        public async Task Add(ReclamacaoDTO ReclamacaoDto)
        {
            var ReclamacaoEntity = _mapper.Map<Reclamacao>(ReclamacaoDto);
            await _ReclamacaoRepository.CreateAsync(ReclamacaoEntity);
        }

        public async Task Update(ReclamacaoDTO ReclamacaoDto)
        {

            var ReclamacaoEntity = _mapper.Map<Reclamacao>(ReclamacaoDto);
            await _ReclamacaoRepository.UpdateAsync(ReclamacaoEntity);
        }

      public async Task Remove(int? id)
{
    var ReclamacaoEntity = await _ReclamacaoRepository.GetByIdAsync(id);
    await _ReclamacaoRepository.RemoveAsync(ReclamacaoEntity);
}
    }
}
