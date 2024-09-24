using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppReclamacoes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReclamacoesController : ControllerBase
    {
        private readonly IReclamacaoService _reclamacaoService;

        public ReclamacoesController(IReclamacaoService reclamacaoService)
        {
            _reclamacaoService = reclamacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reclamacoes = await _reclamacaoService.GetReclamacoes();
            return Ok(reclamacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reclamacao = await _reclamacaoService.GetById(id);
            if (reclamacao == null)
                return NotFound();
            return Ok(reclamacao);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReclamacaoDTO reclamacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (reclamacaoDto.DataReclamacao.Kind == DateTimeKind.Unspecified)
                reclamacaoDto.DataReclamacao = DateTime.SpecifyKind(reclamacaoDto.DataReclamacao, DateTimeKind.Utc);

            if (reclamacaoDto.DataOcorrencia.Kind == DateTimeKind.Unspecified)
                reclamacaoDto.DataOcorrencia = DateTime.SpecifyKind(reclamacaoDto.DataOcorrencia, DateTimeKind.Utc);

            await _reclamacaoService.Add(reclamacaoDto);
            return CreatedAtAction(nameof(GetById), new { id = reclamacaoDto.Id }, reclamacaoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReclamacaoDTO reclamacaoDto)
        {
            if (id != reclamacaoDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reclamacaoService.Update(reclamacaoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reclamacao = await _reclamacaoService.GetById(id);
            if (reclamacao == null)
                return NotFound();

            await _reclamacaoService.Remove(id);
            return NoContent();
        }
    }
}
