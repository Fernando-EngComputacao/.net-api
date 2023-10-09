using System.ComponentModel.DataAnnotations;

namespace DoctorAPI.Models.dto;

public class UpdateAddress
{
    [Required]
    public string place { get; set; }
    [Required]
    public string neighborhood { get; set; }
    [Required]
    public string cep { get; set; }
    [Required]
    public string city { get; set; }
    [Required]
    public string uf { get; set; }
    public string complement { get; set; }
    public string number { get; set; }
    public int active { get; set; }
}