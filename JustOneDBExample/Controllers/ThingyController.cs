using System.Web.Mvc;
using JustOneDBExample.Models;
using NHibernate;
using NHibernate.Linq;

namespace JustOneDBExample.Controllers
{
	public class ThingyController : Controller
	{
		private ISession _session;

		public ThingyController(ISession session)
		{
			_session = session;
		}

		public ActionResult Index()
		{
			return View(_session.Query<Thingy>());
		}

		public ActionResult New()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Thingy thing)
		{
			_session.SaveOrUpdate(thing);
			return RedirectToAction("Index");
		}
	}
}
