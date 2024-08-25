using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
		// GET: Yetenek
		GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();

        public ActionResult Index()
        {
            var yetenekler = repo.List();
			return View(yetenekler);
        }
        [HttpGet]
		public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
		public ActionResult YeniYetenek(TblSkills p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=> x.ID== id);
            repo.TRemove(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x=>x.ID== id);
            return View(yetenek);
		}
		[HttpPost]
		public ActionResult YetenekDuzenle(TblSkills p)
		{   var y = repo.Find(x=>x.ID== p.ID);
            y.Skills=p.Skills;
            y.Rate=p.Rate;
            repo.TUpdate(y);
            return RedirectToAction("Index");
		}
	}
}