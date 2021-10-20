using System.ComponentModel.DataAnnotations;

namespace KnightsTale.Models
{
  public class Castle
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
  }
}