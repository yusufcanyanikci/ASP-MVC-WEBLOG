using System;
using System.Collections.Generic;

namespace weblog.Models.Entities;

public partial class Yazilar
{
    public uint Id { get; set; }

    public int KatId { get; set; }

    public string Baslik { get; set; } = null!;

    public string Ozet { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public int YazarId { get; set; }

    public DateOnly EklenmeTarihi { get; set; }

    public int HitSayisi { get; set; }

    public string Etiketler { get; set; } = null!;
}
