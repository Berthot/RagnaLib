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
        public List<Item> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Item GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}