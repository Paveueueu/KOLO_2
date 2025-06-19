using System.ComponentModel.DataAnnotations;

namespace KOLO_2.DTOs;

public class NewABDTO
{
    [Required]
    public int IdB { get; set; }
    
    [Required]
    public ICollection<NewABCDTO> ABCs { get; set; } = new List<NewABCDTO>();
}

public class NewABCDTO
{
    [Required]
    public string Name { get; set; } = null!;
}