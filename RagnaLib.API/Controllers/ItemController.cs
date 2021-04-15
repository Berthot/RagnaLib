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
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        private readonly IItemService _service;
        private readonly ILogger<ItemController> _logger;


        public ItemController(IItemRepository repo, IItemService service, ILogger<ItemController> logger)
        {
            _repo = repo;
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Item>>> Get()
        {
            return Ok(await _repo.GetAll());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            return Ok(await _repo.GetById(id));
        }
    }
}