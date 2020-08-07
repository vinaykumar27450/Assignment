using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using DAL;
using DataModels;
using System.Drawing;
namespace Application.Controllers
{
    public class HomeController : Controller
    {
        UserRepository user = new UserRepository();
        CityRepository city = new CityRepository();
        WebAppDbContext db = new WebAppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            
            ViewBag.cities = city.getAllCity();
            return View();
        }
        [HttpPost]
        public ActionResult Register(User us)
        {
            var chkUsername = db.tbl_User.Where(m => m.UserName == us.UserName).ToList();
            var chkEmail = db.tbl_User.Where(m => m.Email == us.Email).ToList();
            if(chkUsername.Count != 0)
            {
                ModelState.AddModelError("UserName", "Username already Exist");
                ViewBag.cities = city.getAllCity();
                return View();
            }
            else if(chkEmail.Count() != 0)
            {
                ModelState.AddModelError("Email", "Email already Exist");
                ViewBag.cities = city.getAllCity();
                return View();
            }
            else
            {
                 user.Add(us);
                    return RedirectToAction("Users");
            }
            
            //ViewBag.cities = city.getAllCity();
            //return View();
        }
        public ActionResult PartialViewList()
        {
            ViewBag.users = user.GetAll();
            ViewBag.cities = city.getAllCity();
            return PartialView();
        }
        public ActionResult partialView()
        {
            return View();
        }
        public ActionResult Users()
        {
            ViewBag.cities = city.getAllCity();
            return View(user.GetAll());
        }
        public ActionResult Edit(int id)
        {
            ViewBag.cities = city.getAllCity();
            User user1 = user.GetById(id);
            return View(user1);
        }
        [HttpPost]
        public ActionResult Edit(User us)
        {
            User user1 = user.GetById(us.UserId);

            List<tbl_User> chkUsername = db.tbl_User.Where(m => m.UserName == us.UserName).ToList();
            List<tbl_User> chkEmail = db.tbl_User.Where(m => m.Email == us.Email).ToList();
            if (chkUsername.Count != 0 && chkUsername[0].UserId != us.UserId)
            {
                    ModelState.AddModelError("UserName", "Username already Exist");
                    ViewBag.cities = city.getAllCity();
                    return View(user1);
            }
            else if (chkEmail.Count != 0  && chkEmail[0].UserId != us.UserId)
            {
                    ModelState.AddModelError("Email", "Email already Exist");
                    ViewBag.cities = city.getAllCity();
                    return View(user1);
            }
            else
            {                
                user.Update(us);
                return RedirectToAction("Users");
            }
            //return RedirectToAction("Users");
        }
        public ActionResult Delete(int id)
        {
            user.Delete(id);
            return RedirectToAction("Users");
        }
        public JsonResult ChkMale(string Gender)
        {
            if(Gender == "Male")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
                return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}