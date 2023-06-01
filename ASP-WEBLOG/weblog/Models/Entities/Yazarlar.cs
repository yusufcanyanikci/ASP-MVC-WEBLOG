using System;
using System.Collections.Generic;

namespace weblog.Models.Entities;

public partial class Yazarlar
{
    public int Id { get; set; }

    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public string Cinsiyet { get; set; } = null!;
}
