using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = c.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger1=c.Uruns.Where(x=>x.UrunID==11).ToList();
            cs.Deger2=c.Detays.Where(y=>y.DetayID==11).ToList();
            return View(cs);
        }
    }
}