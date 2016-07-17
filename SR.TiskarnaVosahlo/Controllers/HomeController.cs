using System.Web.Mvc;
using TV.Core;
using TV.Core.Context;
using TV.CoreImpl.Autentication;
using TV.TiskarnaVosahlo.Models;

namespace TV.TiskarnaVosahlo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = Resource.AppTitle;
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Title = Resource.AppTitle;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password)
        {
            try
            {
                SessionId sessionId = new SessionId(HttpContext.Session.SessionID);
                Tiskarna.TiskarnaVosahlo.Autentication.LogIn(sessionId, username, password);
                return Json(new { result = "Redirect", url = Url.Action("Home", "Home") });
            }
            catch (AutenticationException ex)
            {
                return Json(new { result = "Error", message = ex.Message });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Logout()
        {
            try
            {
                SessionId sessionId = new SessionId(HttpContext.Session.SessionID);
                UserContext.Logout();
                return Json(new { result = "Redirect", url = Url.Action("", "") });
            }
            catch (AutenticationException ex)
            {
                return Json(new { result = "Error", message = ex.Message });
            }
        }
    }
}