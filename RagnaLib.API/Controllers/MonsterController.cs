using System.Collections.Generic;
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
        public IEnumerable<Monster> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Monster GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}