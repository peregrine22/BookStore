using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    HttpContext.Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Unable to create user. Pease try again. Error: " + e.Message);
                System.Diagnostics.Debug.Write(e.Message);
            }
            return View(user);
        }
    }
}
