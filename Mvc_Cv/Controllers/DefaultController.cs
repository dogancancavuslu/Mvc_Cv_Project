using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Cv.Models.Entity;
using Mvc_Cv.Repositories;

namespace Mvc_Cv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyal = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyal);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifika()
        {
            var sertifikalarim = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalarim);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {          
            return PartialView();
        }
        
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)

        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }


    }
}