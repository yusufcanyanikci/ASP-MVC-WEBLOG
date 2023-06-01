using System.ComponentModel.DataAnnotations;

namespace weblog.Models.ViewModels;

public partial class ContactVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = "E-Posta boş geçilemez!")]
    public string Eposta { get; set; } = null!;
    [Required(ErrorMessage = "Konu boş geçilemez!")]
    public string Konu { get; set; } = null!;
    [Required(ErrorMessage = "Mesaj boş geçilemez!")]
    public string Mesaj { get; set; } = null!;

    public DateTime TarihSaat { get; set; }

    public string Ip { get; set; } = null!;

    public bool Goruldu { get; set; }
}
