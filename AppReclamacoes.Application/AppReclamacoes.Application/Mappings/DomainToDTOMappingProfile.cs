using AutoMapper;
using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Application.DTOs;

namespace AppReclamacoes.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // Mapeamento de Reclamacao para ReclamacaoDTO e vice-versa
            CreateMap<Reclamacao, ReclamacaoDTO>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.NomeProduto))
                .ReverseMap()
                .ForPath(src => src.Produto.NomeProduto, opt => opt.Ignore()); // Ignorar nome do produto no reverse para evitar conflito

            // Mapeamento de Produto para ProdutoDTO e vice-versa
            CreateMap<Produto, ProdutoDTO>()
                .ReverseMap();
        }
    }
}