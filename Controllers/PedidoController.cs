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
    [Route("api/[controller]")]

    public class PedidoController: ControllerBase
    {

        private readonly AppDbContext _context;
        public PedidoController (AppDbContext context) => _context = context;
        

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            var somaPedidos = _context.Pedidos.Where(u => u.UnidadeId == u.UnidadeId).Sum(p => p.Quantidade);
            var valorTotal = 0m;

            if(_context.Franquias.Any(p => p.CapacidadeEstoque <= somaPedidos ))
                return BadRequest("Capacidade logística da loja excedida.Não é possível receber mais produtos");

            if(_context.Produtos.Any(t => t.Tipo == "Sazonal")){
                valorTotal += 15m;
                Console.WriteLine("Produto sazonal detectado: Adicionando embalagem de presente Premium");

            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return Ok("Criado");

        }
    }
}