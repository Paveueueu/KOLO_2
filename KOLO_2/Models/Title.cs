using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;


public class Title {
    [Key]
    public int Id { get; set; }


    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<CharacterTitle> CharactersTitle { get; set; } = new HashSet<CharacterTitle>();
}