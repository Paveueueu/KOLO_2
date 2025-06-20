using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;


public class Backpack {
    [Key]
    public int Id { get; set; }


    public int Amount { get; set; }


    public int IdItem { get; set; }
    [ForeignKey(nameof(IdItem))]
    public Item Item { get; set; } = null!;

    public int IdCharacter { get; set; }
    [ForeignKey(nameof(IdCharacter))]
    public Character Character { get; set; } = null!;
}