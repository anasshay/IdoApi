using System.ComponentModel.DataAnnotations;

namespace IdoApi.Models
{
  public class Card
  {
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    [Required]
    [DataType(DataType.Duration)]
    public string? Estimate { get; set; }

    [Required]
    public int ImportanceId { get; set; }
    public int StateId { get; set; }
  }
}