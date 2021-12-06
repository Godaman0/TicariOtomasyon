using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int Personelid { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")]
        [StringLength(600)]
        public string PersonelGorsel { get; set; }


        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }

    }
}