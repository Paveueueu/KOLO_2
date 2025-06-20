using KOLO_2.Data;
using KOLO_2.DTOs;
using KOLO_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<GetInfoDto?> GetInfoAsync(int characterId)
    {
        var result = _context.Characters
            .Where(character => character.Id == characterId)
            .Include(character => character.CharacterTitles)
            .ThenInclude(characterTitle => characterTitle.Title)
            .Include(character => character.Backpacks)
            .Select(character => new GetInfoDto
            {
                FirstName = character.FirstName,
                LastName = character.LastName,
                CurrentWeight = character.CurrentWeight,
                MaxWeight = character.MaxWeight,
                Items = character.Backpacks.Select(backpack => new ItemDto
                {
                    ItemName = backpack.Item.Name,
                    ItemWeight = backpack.Item.Weight,
                    ItemAmount = backpack.Amount,
                }).ToList(),
                Titles = character.CharacterTitles.Select(ct => new TitleDto
                {
                    Name = ct.Title.Name,
                    AcquiredAt = ct.AcquiredAt
                }).ToList()
            })
            .FirstOrDefaultAsync();
        
        return await result;
    }

    public async Task<bool> DoesCharacterExist(int idCharacter)
    {
        return await _context.Characters.AnyAsync(e => e.Id == idCharacter);
    }

    public async Task<Character?> GetCharacter(int idCharacter)
    {
        return await _context.Characters.FirstOrDefaultAsync(e => e.Id == idCharacter);
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.Id == itemId);
    }

    public async Task<Item?> GetItem(int itemId)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
    }

    public async Task AddNewBackpackItem(int itemId, int characterId)
    {
        await _context.Backpacks.AddAsync(new Backpack
        {
            IdItem = itemId,
            IdCharacter = characterId,
            Amount = 1
        });
        await _context.SaveChangesAsync();
    }
}