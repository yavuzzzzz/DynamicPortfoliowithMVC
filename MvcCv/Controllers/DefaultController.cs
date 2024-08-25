using System;
using System.Linq;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		// GET: Default
		DbCvEntities db = new DbCvEntities();
		public ActionResult Index()
		{
			var degerler = db.TblAbout.ToList();
			return View(degerler);
		}
		public PartialViewResult SosyalMedya()
		{
			var sosyalMedya = db.TblSocialMedia.Where(x=> x.Durum == true).ToList();
			return PartialView(sosyalMedya);
		}
		public PartialViewResult Deneyim()
		{
			var deneyimler = db.TblExperiences.ToList();
			return PartialView(deneyimler);
		}
		public PartialViewResult Egitim()
		{
			var eğitim = db.TblEducation.ToList();
			return PartialView(eğitim);
		}
		public PartialViewResult Yetenek()
		{
			var yetenek = db.TblSkills.ToList();
			return PartialView(yetenek);
		}
		public PartialViewResult Hobi()
		{
			var hobi = db.TblHobbies.ToList();
			return PartialView(hobi);
		}
		public PartialViewResult Sertifika()
		{
			var sertifika = db.TblSertificates.ToList();
			return PartialView(sertifika);
		}
		[HttpGet]
		public PartialViewResult İletisim()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult İletisim(TblContact t)
		{
			t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.TblContact.Add(t);
			db.SaveChanges();
			return PartialView();
		}
	}
}