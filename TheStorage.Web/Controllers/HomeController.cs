using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStorage.Web.DataAccess;
using TheStorage.Model;

namespace TheStorage.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IRepository db;

        public HomeController(IRepository db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var uploads = db.All<Upload>();

            return View(uploads);
        }

    }
}
