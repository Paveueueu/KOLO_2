using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

[Table("Character_Title")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle {
    public DateTime AcquiredAt { get; set; }
    
    public int CharacterId { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;
    
    public int TitleId { get; set; }
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } = null!;
}