using System.ComponentModel.DataAnnotations;

namespace IdoApi.Models
{
  public class CardModel
  {
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.Duration)]
    public string Estimate { get; set; } = string.Empty;
    [Required]
    public string EstimateUnit { get; set; } = string.Empty;



    [Required]
    public int ImportanceId { get; set; }
    public ImportanceModel? Importance { get; set; }
    
    [Required]
    public int StateId { get; set; }
    public StateModel? prefix { get; set; }

    [Required]
    public int UserId { get; set; }
  }
}