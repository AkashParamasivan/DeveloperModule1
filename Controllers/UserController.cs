using DeveloperModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperModule.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        ReleaseManagementContext db = new ReleaseManagementContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginDetails loginDetails)
        {
            //ReleaseManagementContext db = new ReleaseManagementContext();
            try
            {
                db.EloginDetails.Add(loginDetails);
                db.SaveChanges();
                ViewBag.msg = "User created";
            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
            }
            return View();
        }
        [HttpGet] // Set the attribute to Read 
        public ActionResult Read()
        {
            var data = db.EloginDetails.ToList();
            return View(data);

        }
        public ActionResult LoginUser(string id)
        {
            LoginDetails data = db.EloginDetails.FirstOrDefault(x => x.Username == id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(LoginDetails details)
        {

            LoginDetails data = db.EloginDetails.FirstOrDefault(x => x.Username == details.Username&&x.Password == details.Password);
            if (data != null)
            {

                if (data.Role.ToLower()=="developer")
                {
                    TempData["welcome"] = "Welcome";
                    TempData["Username"] = data.Username;
                    TempData["role"] = data.Role;
                    
                    return RedirectToAction("ReadD");
                }
                else if(data.Role.ToLower() == "tester")
                { 
                    return RedirectToAction("Read");
                }
            }


            return View();

        }

        //Developer section
        [HttpGet] // Set the attribute to Read 
        public ActionResult ReadD()
        {
            var data = db.Developers.ToList();
            return View(data);

        }
        public ActionResult Update(int id)
        {

            Developer selecteddata = db.Developers.Where(x => x.devid == id).SingleOrDefault();
            return View(selecteddata);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Developer model)
        {



            Developer data = db.Developers.FirstOrDefault(x => x.devid == model.devid);


            if (data != null)
            {
                data.devid = model.devid;
                data.projectstatus = model.projectstatus;

                db.SaveChanges();
                ViewBag.msg = "updated";
                //return RedirectToAction("Read");
            }

            return View();

        }


        public ActionResult insertdev()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertdev(Developer dev)
        {
            //ReleaseManagementContext db = new ReleaseManagementContext();
            try
            {
                db.Developers.Add(dev);
                db.SaveChanges();
                ViewBag.msg = "User created";
            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
            }
            return View();
        }
        public ActionResult bugdev()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bugdev(Bug b)
        {
            //ReleaseManagementContext db = new ReleaseManagementContext();
            try
            {
                db.bugs.Add(b);
                db.SaveChanges();
                ViewBag.msg = "User created";
            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
            }
            return View();
        }

       /* public ActionResult ViewBugs(int id)
        {

            Bug selecteddata = db.bugs.Where(x => x.bugid == id).SingleOrDefault();
            return View(selecteddata);


        }*/
        public ActionResult ViewBugs(int? id)
        {

            Bug data = db.bugs.FirstOrDefault(x => x.devid == id);
            if(data != null)
            {
               
                    return View(data);
               

            }
            return View();


        }

        public ActionResult UpdateBug(int id)
        {

            Bug selecteddata = db.bugs.Where(x => x.bugid == id).SingleOrDefault();
            return View(selecteddata);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBug(Bug model)
        {



            Bug data = db.bugs.FirstOrDefault(x => x.bugid == model.bugid);


            if (data != null)
            {
                data.bugid = model.bugid;
                data.bugdesc = model.bugdesc;
                data.devid = model.devid;

                db.SaveChanges();
                ViewBag.msg = "updated";
                //return RedirectToAction("Read");
            }

            return View();

        }

        public ActionResult ViewModule(int? id)
        {
            Module data = db.Modules.FirstOrDefault(x => x.devid == id);
            if (data != null)
            {

                return View(data);


            }
            return View();


        }

        public ActionResult insertModule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertmodule(Module mod)
        {
            //ReleaseManagementContext db = new ReleaseManagementContext();
            if (mod != null)
            {
                try
                {
                    db.Modules.Add(mod);
                    //db.Modules.Add(mod);
                    db.SaveChanges();
                    ViewBag.msg = "User created";
                }
                catch (Exception ex)
                {

                    ViewBag.msg = ex.Message;
                }
            }
            return View();
        }
    }



    


}
