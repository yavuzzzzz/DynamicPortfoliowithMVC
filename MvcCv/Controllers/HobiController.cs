using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	public class HobiController : Controller
	{
		// GET: Hobi
		GenericRepository<TblHobbies> repo = new GenericRepository<TblHobbies>();
		[HttpGet]
		public ActionResult Index()
		{
			var hobiler = repo.List();
			return View(hobiler);
		}
		[HttpPost]
		public ActionResult Index(TblHobbies p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Description1 = p.Description1;
			t.Description2 = p.Description2;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}