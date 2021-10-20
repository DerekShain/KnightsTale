using System.ComponentModel.DataAnnotations;

namespace KnightsTale.Models
{
  public class Knight
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Sword { get; set; }
    public int Skill { get; set; }
    public string Type { get; set; }
  }
}