using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Cv.Models.Entity;
using Mvc_Cv.Repositories;

namespace Mvc_Cv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();



        public ActionResult Index()
        {
            var sertfika = repo.List();
            return View(sertfika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.ID = t.ID;
            sertifika.Tarih = t.Tarih;
            repo.TUptade(sertifika);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}