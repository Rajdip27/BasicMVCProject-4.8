using Autofac;
using BankSolution.Data;
using BankSolution.Models;
using BankSolution.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BankSolution.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILifetimeScope _lifetimeScope;
        private readonly BankContext _bankContext;
        public HomeController(ILifetimeScope lifetimeScope, BankContext bankContext)
        {
            _lifetimeScope = lifetimeScope;
            _bankContext = bankContext;
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

        public ActionResult EmployeeReport()
        {
            //var report = new LocalReport() { ReportPath=Server.MapPath("~/Reports/Report1.rdlc") };
            //report.Render("pdf",)

            var reportDataSource = new List<ReportDataSource>() { new ReportDataSource("DsEmploye", _bankContext.Employees.ToList() ) };

            var config = new ReportConfig { ReportFilePath = Server.MapPath("~/Reports/Report1.rdlc") };
            return new ReportResult(config, reportDataSource);
        }
    }
}