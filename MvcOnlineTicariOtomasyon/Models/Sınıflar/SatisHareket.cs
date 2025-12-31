using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        
        public int Urunid {  get; set; }

        
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        [ForeignKey("Urunid")]
        public virtual Urun Urun { get; set; }
        [ForeignKey("Cariid")]
        public virtual Cariler Cariler { get; set; }
        [ForeignKey("Personelid")]

        public virtual Personel Personel { get; set; }

    }
}