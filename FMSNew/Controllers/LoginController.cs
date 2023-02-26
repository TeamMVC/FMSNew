using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FMSAPI.Models;

namespace FMSNew.Controllers
{


    public class LoginController : Controller
    {
        public string Url = "http://localhost:61500/api/";
        // GET: Login
        public ActionResult Login()
        {
            tbl_UserLogin User = new tbl_UserLogin();
            User.Email = string.Empty;
            User.Passward = string.Empty;
            return View("~/Views/Login/Login.cshtml", User);
        }

        [HttpPost]
        public ActionResult Login(tbl_UserLogin User_login)
        {

            IEnumerable<tbl_UserLogin> login = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                //HTTP GET
                var responseTask = client.GetAsync("UserLoginAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<tbl_UserLogin>>();
                    readTask.Wait();

                    login = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    login = Enumerable.Empty<tbl_UserLogin>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            if (login != null)
            {
                var User = login.Where(u => u.Email == User_login.Email && u.Passward == User_login.Passward).SingleOrDefault();
                if (User != null)
                {
                    if (User.Email != null && User.Passward != null)
                    {
                        Session["UserName"] = User.Name;
                    }

                    Session["UserId"] = User.Id;
                    Session["RoleId"] = User.RoleId;
                    FormsAuthentication.SetAuthCookie(User.Name, false);

                    return View("~/Views/Dashboard.cshtml");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        //public ActionResult Registration()
        //{
        //    var dlist = RetuningData.ReturnigList<CenterModel>("usp_getCenter", null);
        //    ViewBag.Center = new SelectList(dlist, "CenterId", "CenterName");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Registration(RegistrationModel reg)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@Name", reg.name);
        //    param.Add("@Email", reg.emalid);
        //    param.Add("@Passward", reg.password);
        //    param.Add("@Status", reg.status);
        //    param.Add("@CenterId", 1);

        //    int i = RetuningData.AddOrSave<int>("usp_getUserLogin", param);
        //    if (i > 0)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}