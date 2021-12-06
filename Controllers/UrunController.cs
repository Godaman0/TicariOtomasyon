using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.urunlers select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunlerAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList() select new SelectListItem
                    { Text = x.KategoriAd, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniUrun(Urunler p)
        {
            c.urunlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.urunlers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           { Text = x.KategoriAd, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            
            var urundeger = c.urunlers.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urunler p)
        {
            var urn = c.urunlers.Find(p.UrunlerId);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.UrunlerAd = p.UrunlerAd;
            urn.UrunlerGorsel = p.UrunlerGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.urunlers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger2 = c.urunlers.Find(id);
            ViewBag.dgr2 = deger2.UrunlerId;
            ViewBag.dgr3 = deger2.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
            
        }
    }
}