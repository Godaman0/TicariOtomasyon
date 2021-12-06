﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.urunlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.urunlers.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.urunlers select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.urunlers.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.urunlers orderby x.SatisFiyat descending select x.UrunlerAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.urunlers orderby x.SatisFiyat ascending select x.UrunlerAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.urunlers.Count(x => x.UrunlerAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.urunlers.Count(x => x.UrunlerAd == "Abra A5").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.urunlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.urunlers.Where(u => u.UrunlerId == (c.SatisHarekets.GroupBy(x => x.Urunlerid).OrderByDescending(z =>
            z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunlerAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y =>(decimal?) y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepatmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.urunlers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu3 = from x in c.urunlers
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
    }
}