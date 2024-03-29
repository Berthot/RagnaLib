using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonsterController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;
    private readonly IMonsterService _service;
    private readonly ILogger<MonsterController> _logger;


    public MonsterController(IMonsterService service, ILogger<MonsterController> logger, IMapper mapper, IMemoryCache memoryCache)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
        _memoryCache = memoryCache;
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
    [Route("{id:int}")]
    public async Task<ActionResult<MonsterDto>> GetById(int id)
    {
        try
        {
            var cacheKey = $"Monster-{id.ToString()}";
            if (_memoryCache.TryGetValue(cacheKey, out MonsterDto mapped)) return Ok(mapped);

            var monster = await _service.GetMonsterById(id);
            
            if (monster == null)
                return NotFound("Monstro não encontrado");

            mapped = _mapper.Map<MonsterDto>(monster);
            
            _memoryCache.Set(cacheKey, mapped, TimeSpan.FromDays(2));
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            _logger.LogInformation($"Request {Request?.Method}: {Request?.Path.Value}");

            return Ok(mapped);
        }
        catch (Exception e)
        {
            return BadRequest("Erro ao captar um monstro");
        }

    }
}