using System.ComponentModel.DataAnnotations;

namespace KOLO_2.DTOs;

public class GetInfoDto
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int CurrentWeight { get; set; }

    [Range(1, int.MaxValue)]
    public int MaxWeight { get; set; }
    
    public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();
    public ICollection<TitleDto> Titles { get; set; } = new List<TitleDto>();
}

public class ItemDto
{
    [MaxLength(100)]
    public string ItemName { get; set; } = string.Empty;
    
    [Range(1, int.MaxValue)]
    public int ItemWeight { get; set; }
    
    [Range(1, int.MaxValue)]
    public int ItemAmount { get; set; }
}

public class TitleDto
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public DateTime AcquiredAt { get; set; }
}

