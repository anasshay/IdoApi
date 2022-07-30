using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace IdoApi.Models
{
  public class Importance
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}