using DIYCraftsAndProjectsMVC.Mapper;
using DIYCraftsAndProjectsMVC.Models;
using DIYCraftsAndProjectsMVC.Models.BLModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIYCraftsAndProjectsMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly CraftsAndProjectsDbContext _context;

        public AccountController(CraftsAndProjectsDbContext context)
        {
            _context = context;
        }

        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }

        // GET: AccountController/Create
        //public ActionResult Create()
        //{
        //    return View();e
        //}

        // POST: AccountController/Create
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                var user = _context.Users.Where(x => x.Email == login.Email && x.Password == login.Password).Count();

                if (user > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login");
            }
            catch
            {
                return RedirectToAction("Login");
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Register()
        {
            ViewBag.Countries = _context.Countries;

            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        public ActionResult Register(Account account)
        {
            try
            {
                _context.Users.Add(UserAccountMapper.MapAccountToUser(account));
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
