using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        //ürün
        //cari
        // personel
        public DateTime Tarih  { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int Urunlerid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        public virtual Urunler Urunlers { get; set; }

        public virtual Cariler Carilers { get; set; }

        public virtual Personel Personels { get; set; }
    }
}