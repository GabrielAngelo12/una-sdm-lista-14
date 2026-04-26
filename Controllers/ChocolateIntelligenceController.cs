using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324118333.Data;
using Microsoft.AspNetCore.Mvc;

namespace CacauShowApi324118333.Controllers
{
    [ApiController]
    [Route("api/intelligence/estoque-regional")]
    public class ChocolateIntelligenceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ChocolateIntelligenceController(AppDbContext context) => _context = context;

            [HttpGet]
            public IActionResult Get()
            {
                System.Threading.Thread.Sleep(2000);
                var lotesAtivos = _context.LoteProducoes.Where(p => p.Status == "Ativo");
                var cidades = _context.Franquias
                .Where(f => lotesAtivos.Any(l => l.Id == f.Id))
                .GroupBy(p => p.Cidade)
                .Select(g => new
                {
                    Cidade = g.Key,
                    TotalItens = g.Sum(t => _context.Pedidos.Where(p => p.Id == t.Id).Sum(p => p.Quantidade))
                })
                .ToList();

                return Ok(cidades);
                
            }


    }
}