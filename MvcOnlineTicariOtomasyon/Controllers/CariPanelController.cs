using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        public ActionResult Index()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;

            var mail = (string)Session["CariMail"];
            var degerler = c.mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid= mailid;
            var toplamsatis = c.SatisHarekets.Count(x => x.Cariid == mailid);

            var toplamtutar = c.SatisHarekets
                .Where(x => x.Cariid == mailid)
                .Select(x => (decimal?)x.ToplamTutar)
                .Sum() ?? 0;

            var toplamurunsayisi = c.SatisHarekets
                .Where(x => x.Cariid == mailid)
                .Select(x => (int?)x.Adet)
                .Sum() ?? 0;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z=>z.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1= gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var degerler =c.mesajlars.Where(x=>x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi=c.mesajlars.Count(x=>x.Alici==mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi=c.mesajlars.Count(x=>x.Gonderici==mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var mail = (string)Session["CariMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m)
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var mail = (string)Session["CariMail"];
            m.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var k = from x in c.KargoDetays select x;
            k=k.Where(y=>y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;


            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            CariKontrol();

            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }
        public PartialViewResult Partial2()
        {
            CariKontrol();

            var mail = Session["CariMail"] as string;

            var mesajlar = string.IsNullOrEmpty(mail)
                ? new List<mesajlar>()
                : c.mesajlars
                    .Where(x => x.Alici == mail)
                    .OrderByDescending(x => x.Tarih)
                    .ToList();

            return PartialView(mesajlar);
        }
        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var kontrol = CariKontrol();
            if (kontrol != null)
                return kontrol;

            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd=cr.CariAd;
            cari.CariSoyad=cr.CariSoyad;
            cari.CariSifre=cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        private ActionResult CariKontrol()
        {
            if (Session["CariMail"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return null;
        }

        public ActionResult Urunler()
        {

            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        public ActionResult SatinAl(int id)
        {
            var mail = (string)Session["CariMail"];
            var cariId = c.Carilers
                .Where(x => x.CariMail == mail)
                .Select(y => y.CariID)
                .FirstOrDefault();

            var urun = c.Uruns.Find(id);

            SatisHareket s = new SatisHareket();
            s.Urunid = id;
            s.Cariid = cariId;

            s.Personelid = 1; // 

            s.Adet = 1;
            s.Fiyat = urun.SatisFiyat;
            s.ToplamTutar = urun.SatisFiyat;
            s.Tarih = DateTime.Now;

            c.SatisHarekets.Add(s);
            c.SaveChanges();

            return RedirectToAction("Siparislerim");
        }


    }
}