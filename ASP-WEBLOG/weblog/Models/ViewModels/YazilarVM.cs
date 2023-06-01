namespace weblog.Models.ViewModels;
public class YazilarVM
{
    public uint Id { get; set; }

    public string KategoriAdi { get; set; }

    public string Baslik { get; set; } = null!;

    public string Ozet { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public string YazarAdSoyad { get; set; }

    public DateOnly EklenmeTarihi { get; set; }

    public int HitSayisi { get; set; }

    public string Etiketler { get; set; } = null!;
}