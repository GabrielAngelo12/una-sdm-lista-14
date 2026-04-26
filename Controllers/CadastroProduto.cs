using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324118333.Data;
using CacauShowApi324118333.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacauShowApi324118333.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class CadastroProduto : ControllerBase
    {
        private readonly AppDbContext _context;
        public CadastroProduto(AppDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CriarProduto), new { id = produto.Id }, produto);
        }
    }
}