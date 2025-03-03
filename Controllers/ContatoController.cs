using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Context;
using TodoApi.Emtities;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        [HttpPost("AdicionarContato")]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato); // Adiciona o contato na lista
            _context.SaveChanges(); // Salva as alterações
            return CreatedAtAction("GetContato", new { id = contato.Id }, contato); // Retorna a resposta com o contato criado
        }
        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }
        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            contatoBanco.Nome = contato.Nome;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}