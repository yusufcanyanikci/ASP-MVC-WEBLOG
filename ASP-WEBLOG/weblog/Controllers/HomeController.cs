﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using weblog.Models;
using weblog.Models.Entities;
using weblog.Models.ViewModels;

namespace weblog.Controllers;

public class HomeController : Controller
{
    private readonly WeblogContext db = new WeblogContext(); // dependency injection nesnesi
    public HomeController(WeblogContext _db) // Dep'i parametre olarak ekledik.
    {
        db = _db; // dependency injection yaptık. 
    }

    [Route("/")]
    public IActionResult Index()
    {
        List<YazilarVM> yazilar = (from x in db.Yazilars
                                   join y in db.Yazarlars on x.YazarId equals Convert.ToInt32(y.Id)
                                   join k in db.Kategorilers on x.KatId equals Convert.ToInt32(k.Id)
                                   select new YazilarVM
                                   {
                                       Id = x.Id,
                                       KategoriAdi = k.Adi,
                                       Baslik = x.Baslik,
                                       Ozet = x.Ozet,
                                       Icerik = x.Icerik,
                                       YazarAdSoyad = y.Adi + " " + y.Soyadi,
                                       HitSayisi = x.HitSayisi,
                                       Etiketler = x.Etiketler,
                                       EklenmeTarihi = x.EklenmeTarihi
                                   }).OrderByDescending(a => a.EklenmeTarihi).Take(10).ToList();

        return View(yazilar); // çektiğimiz verileri view'e gönderiyoruz
    }

    [Route("/YaziDetay/{id}")]
    public IActionResult YaziDetay(int id)
    {
        YazilarVM YaziDetay = (from x in db.Yazilars
                               join y in db.Yazarlars on x.YazarId equals Convert.ToInt32(y.Id)
                               join k in db.Kategorilers on x.KatId equals Convert.ToInt32(k.Id)
                               where x.Id == id
                               select new YazilarVM
                               {
                                   Id = x.Id,
                                   KategoriAdi = k.Adi,
                                   Baslik = x.Baslik,
                                   Ozet = x.Ozet,
                                   Icerik = x.Icerik,
                                   YazarAdSoyad = y.Adi + " " + y.Soyadi,
                                   EklenmeTarihi = x.EklenmeTarihi,
                                   HitSayisi = x.HitSayisi,
                                   Etiketler = x.Etiketler

                               }).FirstOrDefault();

        return View(YaziDetay);
    }

    [Route("/Contact")]
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [Route("/Contact")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(ContactVM gelenData)
    {
        if (!ModelState.IsValid)
        {
            return View(gelenData);
        }

        Iletisim yeniData = new Iletisim
        {
            Eposta = gelenData.Eposta,
            Konu = gelenData.Konu,
            Mesaj = gelenData.Mesaj,
            TarihSaat = DateTime.Now,
            Ip = gelenData.Ip,
            Goruldu = gelenData.Goruldu,
        };
        await db.AddAsync(yeniData);
        await db.SaveChangesAsync();

        return Redirect("/Contact");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
