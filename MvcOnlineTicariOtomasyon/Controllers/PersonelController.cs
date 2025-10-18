using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
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
            var perso = c.Personels.Find(p.PersonelID);
            perso.PersonelAd = p.PersonelAd;
            perso.PersonelSoyad = p.PersonelSoyad;
            perso.PersonelGorsel = p.PersonelGorsel;
            perso.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}