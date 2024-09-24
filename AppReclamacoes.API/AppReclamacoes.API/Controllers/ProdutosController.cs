using AppReclamacoes.Application.DTOs;
using AppReclamacoes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppReclamacoes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            return Ok(produtos);
        }

        // GET: api/produtos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoService.Add(produtoDto);
            return CreatedAtAction(nameof(GetById), new { id = produtoDto.Id }, produtoDto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoService.UpdateAsync(produtoDto);
            return NoContent();
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null)
                return NotFound();

            await _produtoService.RemoveAsync(id);
            return NoContent();
        }
    }
}
