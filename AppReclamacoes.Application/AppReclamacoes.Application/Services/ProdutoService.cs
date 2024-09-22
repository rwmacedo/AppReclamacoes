using AutoMapper;
using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppReclamacoes.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosAsync()
        {
            var produtosEntity = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetByIdAsync(int? id)
{
    if (id == null)
    {
        return null; 
    }

    var produtoEntity = await _produtoRepository.GetByIdAsync(id);
    return _mapper.Map<ProdutoDTO>(produtoEntity);
}


        public async Task Add(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CreateAsync(produtoEntity);
        }

        public async Task UpdateAsync(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }

public async Task RemoveAsync(int? id)
{
    var produtoEntity = await _produtoRepository.GetByIdAsync(id);
    await _produtoRepository.RemoveAsync(produtoEntity);
}

    }
}
