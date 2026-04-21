using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324118333.Data;
using CacauShowApi324118333.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324118333.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ControleQualidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ControleQualidadeController(AppDbContext context) => _context = context;
         
         [HttpPost]
         public IActionResult Post(LoteProducao loteProducao)
        {
            var produtoId = _context.Produtos.Any(a => a.Id == loteProducao.ProdutoId);
            var dataFutura = _context.LoteProducoes.Any(b => b.DataFabricacao > DateTime.Now);

            if(produtoId == false)
                return NotFound("Produto não cadastrado");

            if (dataFutura)
                return Conflict("Lote inválido: Data de fabricação não pode ser maior que a data atual");

            _context.LoteProducoes.Add(loteProducao);
            _context.SaveChanges();

            return Ok("Lote de Produção criado");
        }
        
    }
}