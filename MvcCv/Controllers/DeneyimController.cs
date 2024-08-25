using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }  [HttpPost]
        public ActionResult DeneyimEkle(TblExperiences p)
        {
           repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil( int id)
        {
            TblExperiences t = repo.Find(x=> x.ID== id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
			TblExperiences t = repo.Find(x => x.ID == id);
            return View(t);
		} [HttpPost]
        public ActionResult DeneyimGetir(TblExperiences p)
        {
			TblExperiences t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle= p.Subtitle;
            t.Date= p.Date;
            t.Description= p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
		}
    }
}