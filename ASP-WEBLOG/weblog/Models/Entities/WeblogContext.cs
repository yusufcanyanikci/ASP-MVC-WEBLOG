using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace weblog.Models.Entities;

public partial class WeblogContext : DbContext
{
    public WeblogContext()
    {
    }

    public WeblogContext(DbContextOptions<WeblogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iletisim> Iletisims { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Yazarlar> Yazarlars { get; set; }

    public virtual DbSet<Yazilar> Yazilars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin5_turkish_ci")
            .HasCharSet("latin5");

        modelBuilder.Entity<Iletisim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("iletisim");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eposta)
                .HasMaxLength(100)
                .HasColumnName("eposta");
            entity.Property(e => e.Goruldu).HasColumnName("goruldu");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ip");
            entity.Property(e => e.Konu)
                .HasMaxLength(150)
                .HasColumnName("konu");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(600)
                .HasColumnName("mesaj");
            entity.Property(e => e.TarihSaat)
                .HasColumnType("datetime")
                .HasColumnName("tarihSaat");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kategoriler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasMaxLength(70)
                .HasColumnName("adi");
            entity.Property(e => e.Sira).HasColumnName("sira");
        });

        modelBuilder.Entity<Yazarlar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("yazarlar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adi)
                .HasMaxLength(50)
                .HasColumnName("adi");
            entity.Property(e => e.Cinsiyet)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("cinsiyet");
            entity.Property(e => e.Soyadi)
                .HasMaxLength(50)
                .HasColumnName("soyadi");
        });

        modelBuilder.Entity<Yazilar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("yazilar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Baslik)
                .HasMaxLength(100)
                .HasColumnName("baslik");
            entity.Property(e => e.EklenmeTarihi).HasColumnName("eklenmeTarihi");
            entity.Property(e => e.Etiketler)
                .HasMaxLength(150)
                .HasColumnName("etiketler");
            entity.Property(e => e.HitSayisi).HasColumnName("hitSayisi");
            entity.Property(e => e.Icerik)
                .HasColumnType("mediumtext")
                .HasColumnName("icerik");
            entity.Property(e => e.KatId).HasColumnName("katId");
            entity.Property(e => e.Ozet)
                .HasMaxLength(250)
                .HasColumnName("ozet");
            entity.Property(e => e.YazarId).HasColumnName("yazarId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
