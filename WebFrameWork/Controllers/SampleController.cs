using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVC.Template.Web.Domain;
using MVC.Template.Web.Models;
using ILoggingService = MVC.Template.Web.Domain.ILoggingService;
using MVC.Template.Web.Filters;

namespace MVC.Template.Web.Controllers
{
    public class SampleController : Controller
    {
        private readonly IWorkingService _working;
        private readonly ILoggingService _logging;
        public SampleController(IWorkingService work, ILoggingService log)
        {
            _working = work;
            _logging = log;

        }

        // GET: Sample
        public ActionResult Widget()
        {
            return View(_working.GetAllIssues().ToList());
        }

        public ActionResult Issue()
        {
            return PartialView("Partials/Issue");
        }

        [HttpPost, Log("Add issue")]
        public ActionResult Widget(Issue model)
        {
            if (!ModelState.IsValid)
                RedirectToAction("Widget");
            else
            {
                _working.InsertIssue(model);
                
            }
            return RedirectToAction("Widget");
        }
    }
}