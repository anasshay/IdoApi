using System.ComponentModel.DataAnnotations;

namespace IdoApi.Models
{
  public class UserModel
  {
    public int Id { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;

    public string Photo { get; set; } = string.Empty;
  }
}