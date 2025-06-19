using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

public class B
{
    [Key]
    public int Id { get; set; }
    
    
    
    public ICollection<AB> ABs { get; set; }  = new HashSet<AB>();
}