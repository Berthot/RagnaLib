using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Domain.Services;

namespace RagnaLib.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private readonly IMonsterRepository _repo;
        private readonly IMonsterService _service;
        private readonly ILogger<MonsterController> _logger;


        public MonsterController(IMonsterRepository repo, IMonsterService service, ILogger<MonsterController> logger)
        {
            _repo = repo;
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Monster>>> Get()
        {
            var monsters = await _service.GetAllMonsters();
            if (monsters == null)
                return NotFound("Não foi possivel capturar todos os monstros");
            return Ok(monsters);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Monster>> GetById(int id)
        {
            var monster = await _service.GetMonsterById(id);
            if (monster == null)
                return NotFound("Monstro não encontrado");
            return Ok(monster);
        }
    }
}