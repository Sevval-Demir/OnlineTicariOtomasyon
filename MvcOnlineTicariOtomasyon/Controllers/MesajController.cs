using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class MesajController : Controller
    {
        // GET: Mesaj
        Context c = new Context();

        public ActionResult CariMesajlar()
        {
            // Cari tarafından gönderilen mesajlar
            var mesajlar = c.mesajlars
                .Where(x => x.Gonderici != "admin@mail.com")
                .OrderByDescending(x => x.MesajID)
                .ToList();

            return View(mesajlar);
        }
    }
}