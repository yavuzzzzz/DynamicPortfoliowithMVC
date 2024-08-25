using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	public class HakkimdaController : Controller
	{
		// GET: Hakkimda
		GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
		[HttpGet]
		public ActionResult Index()
		{
			var hakkimda = repo.List();
			return View(hakkimda);
		}
		[HttpPost]
		public ActionResult Index(TblAbout p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Name = p.Name;
			t.Surname = p.Surname;
			t.Mail = p.Mail;
			t.Description = p.Description;
			t.Address = p.Address;
			t.PhoneNumber = p.PhoneNumber;
			t.Image = p.Image;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}