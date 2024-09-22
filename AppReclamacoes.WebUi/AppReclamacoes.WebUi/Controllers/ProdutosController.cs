using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppReclamacoes.WebUI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _ProdutoService;
        public ProdutosController(IProdutoService ProdutoService)
        {
            _ProdutoService = ProdutoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Produtos = await _ProdutoService.GetProdutosAsync();
            return View(Produtos);
        }
    }
}
