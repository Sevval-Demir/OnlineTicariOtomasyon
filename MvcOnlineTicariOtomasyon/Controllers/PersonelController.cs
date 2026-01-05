using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c= new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel pers)
        {
            if(Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/Images/Personel/" + dosyaadi ;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                pers.PersonelGorsel = "/Images/Personel/" + dosyaadi ;
            }
            c.Personels.Add(pers);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/Images/Personel/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images/Personel/" + dosyaadi;
            }
            var perso = c.Personels.Find(p.PersonelID);
            perso.PersonelAd = p.PersonelAd;
            perso.PersonelSoyad = p.PersonelSoyad;
            perso.PersonelGorsel = p.PersonelGorsel;
            perso.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}