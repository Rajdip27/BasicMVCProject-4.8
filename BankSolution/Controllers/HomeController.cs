using Autofac;
using BankSolution.Models;
using BankSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BankSolution.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILifetimeScope _lifetimeScope;

        public HomeController(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public HomeController()
        {
           
        }

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

        public async Task<PartialViewResult> GetUserInfo(int id)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var userService = scope.Resolve<IUserServices>();
                var user = await userService.GetUserById(id);

                return PartialView("~/Views/Shared/Partial/_partialUserInfoFromAction.cshtml", user);
            }
        }
    }
}