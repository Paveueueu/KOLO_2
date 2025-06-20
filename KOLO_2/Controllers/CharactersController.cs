using System.Transactions;
using KOLO_2.DTOs;
using KOLO_2.Models;
using KOLO_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLO_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetInfo(int characterId)
    {
        var result = await _dbService.GetInfoAsync(characterId);
        return Ok(result);
    }
    
    [HttpPost("{idCharacter}/backpacks")]
    public async Task<IActionResult> AddNew([FromBody] AddItemDto addItemDto, int idCharacter)
    {
        var character = await _dbService.GetCharacter(idCharacter);
        
        if (character == null)
            return NotFound("Character does not exist");
        
        var items = new List<Item>();
        foreach (var itemId in addItemDto.ItemIds)
        {
            var item = await _dbService.GetItem(itemId);
            if (item == null)
                return NotFound("Item does not exist");
            items.Add(item);
        }
        
        var itemSumWeight = items.Sum(item => item.Weight);
        
        if (itemSumWeight + character.CurrentWeight > character.MaxWeight)
            return BadRequest("Weight is too big");

        foreach (var item in items)
        {
            await _dbService.AddNewBackpackItem(item.Id, idCharacter);
        }
        
        return Created();
    }
}