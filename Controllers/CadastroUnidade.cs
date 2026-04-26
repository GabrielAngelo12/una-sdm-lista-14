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
    [Route("api/unidades")]
    public class CadastroUnidade : ControllerBase
    {
        private readonly AppDbContext _context;

        public CadastroUnidade(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult CriarUnidade([FromBody] Franquia franquia)
        {
            _context.Franquias.Add(franquia);
            _context.SaveChanges();
            return Ok("Unidade cadastrada com sucesso");
        }
    }
}