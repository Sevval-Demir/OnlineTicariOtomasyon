using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir",fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo=f.FaturaSeriNo; 
            fatura.FaturaSiraNo=f.FaturaSiraNo;
            fatura.VergiDairesi=f.VergiDairesi;
            fatura.Tarih=f.Tarih;
            fatura.Saat = f.Saat;
            fatura.ToplamTutar=f.ToplamTutar;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars
                .Include(x => x.FaturaKalems)
                .ToList();
            cs.deger2 = c.Faturalars.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSiraNo,DateTime Tarih,string VergiDairesi,string Saat,string TeslimEden,string TeslimAlan,string ToplamTutar, FaturaKalem[] Kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat= Saat;
            f.TeslimEden= TeslimEden;
            f.TeslimAlan= TeslimAlan;
            f.ToplamTutar= decimal.Parse(ToplamTutar);
            c.Faturalars.Add(f);
            c.SaveChanges();
            foreach(var x in Kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama=x.Aciklama;
                fk.BirimFiyat=x.BirimFiyat;
                fk.Faturaid=x.Faturaid;
                fk.Miktar=x.Miktar;
                fk.Tutar=x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}