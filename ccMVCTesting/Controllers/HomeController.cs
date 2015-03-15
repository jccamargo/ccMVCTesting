using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccMVCTesting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //
        public ActionResult SelectTheme(string ThemeName = "")
        {
            List<string> Themes = new List<string>();
            Themes.Add("cosmo");
            Themes.Add("cyborg");
            Themes.Add("darkly");
            Themes.Add("flatly");
            Themes.Add("paper");
            Themes.Add("sandstone");
            Themes.Add("superhero");
            Themes.Add("united");
            Themes.Add("yeti");
            //
            Session["ThemeName"] = "";
            if (! String.IsNullOrEmpty(ThemeName))
            {
                if(Themes.Contains(ThemeName.ToLower()))
                    Session["ThemeName"] = ThemeName;
            } // !
            //
            return View("Index");
            //
        } // SelectTheme

    }
}