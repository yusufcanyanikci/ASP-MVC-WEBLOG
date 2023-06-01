using System;
using System.Collections.Generic;

namespace weblog.Models.Entities;

public partial class Kategoriler
{
    public uint Id { get; set; }

    public string Adi { get; set; } = null!;

    public int Sira { get; set; }
}
