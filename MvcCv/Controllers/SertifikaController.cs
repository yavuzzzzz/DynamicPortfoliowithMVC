using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertificates> repo=new GenericRepository<TblSertificates>();
        public ActionResult Index()
		{
            var sertifika = repo.List();
			return View(sertifika);
		}
        [HttpGet]
        public ActionResult SertifikaGetir(int id) 
        {
            var sertifika = repo.Find(x=> x.ID== id);
            return View(sertifika);
		}
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertificates t)
        {
            var sertifika=repo.Find(x=>x.ID== t.ID);
            sertifika.Description = t.Description;
            sertifika.Date=t.Date;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika() 
        {
			return View(); 
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertificates t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID == id);
            repo.TRemove(sertifika);
            return RedirectToAction("Index");
        }
	}
}