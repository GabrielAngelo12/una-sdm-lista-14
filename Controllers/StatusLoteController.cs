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
    public class StatusLoteController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        public StatusLoteController(AppDbContext context) => _context = context;

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, string novoStatus){
            
            var prod_id = _context.LoteProducoes.Find(id);
            var lotesDescartados = _context.LoteProducoes.Where(d => d.Status == "Descartado");

            if(prod_id.Status == "Descartado")
                return BadRequest("O produto foi descartado e esse status não pode ser alterado");
           
            prod_id.Status = novoStatus;
            _context.SaveChanges();

            return Ok("Status alterado com sucesso");
        }

    }
}