using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
	[Authorize]
	public class EgitimController : Controller
    {
		// GET: Egitim
		GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
		
		public ActionResult Index()
        {
            var egitim = repo.List();
			return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=>x.ID== id);
            repo.TRemove(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim= repo.Find(x=>x.ID== id);
            return View(egitim);
		}
		[HttpPost]
		public ActionResult EgitimDuzenle(TblEducation p)
		{
			if (!ModelState.IsValid)
			{
				return View("EgitimDuzenle");
			}
			var egitim = repo.Find(x => x.ID == p.ID);
            egitim.Title = p.Title;
            egitim.Subtitle1= p.Subtitle1;
            egitim.Subtitle2= p.Subtitle2;
            egitim.Date= p.Date;
            egitim.GPA= p.GPA;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
			return View(egitim);
		}
	}
}