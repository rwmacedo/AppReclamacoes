using AutoMapper;
using AppReclamacoes.Domain.Entities;
using AppReclamacoes.Application.DTOs;

namespace AppReclamacoes.Application.Mappings
{
        public class DomainToDTOMappingProfile : Profile
        {
            public DomainToDTOMappingProfile()
            {
                CreateMap<Reclamacao, ReclamacaoDTO>().ReverseMap();
                CreateMap<Produto, ProdutoDTO>().ReverseMap();
            }
        }
}