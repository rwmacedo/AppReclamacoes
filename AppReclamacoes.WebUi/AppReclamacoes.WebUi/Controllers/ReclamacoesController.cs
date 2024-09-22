using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace AppReclamacoes.WebUI.Controllers
{
    public class ReclamacoesController : Controller
    {
        private readonly IReclamacaoService _reclamacaoService;

        public ReclamacoesController(IReclamacaoService reclamacaoAppService)
        {
            _reclamacaoService = reclamacaoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reclamacoes = await _reclamacaoService.GetReclamacoes();
            return View(reclamacoes);
        }
    }
}
