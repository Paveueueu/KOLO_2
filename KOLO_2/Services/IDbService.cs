using KOLO_2.DTOs;
using KOLO_2.Models;

namespace KOLO_2.Services;

public interface IDbService
{
    Task<GetInfoDto?> GetInfoAsync(int characterId);
    Task<bool> DoesCharacterExist(int idCharacter);
    Task<Character?> GetCharacter(int idCharacter);
    Task<bool> DoesItemExist(int itemId);
    Task<Item?> GetItem(int itemId);
    Task AddNewBackpackItem(int itemId, int characterId);
}