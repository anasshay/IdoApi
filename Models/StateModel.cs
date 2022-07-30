using System.ComponentModel.DataAnnotations;

namespace IdoApi.Models
{
  public class StateModel
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
  }
}