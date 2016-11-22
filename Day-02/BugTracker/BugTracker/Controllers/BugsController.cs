using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers

{
   public class BugViewModel
    {
        public int ClosedCount;
        public IList<IBug> Bugs;
        public NewBugModel NewBug = new NewBugModel();
       
    }
    
    public class NewBugModel
    {
        public string Name { get; set; }
        public bool IsClosed { get; set; } = true;
        public IList<KeyValuePair<string, string>> SeverityCodes;
        public string Severity { get; set; }
    }

    public class BugsController : Controller
    {

        public static IList<IBug> bugs = new List<IBug>();
        public IList<KeyValuePair<string, string>> SeverityCodes = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("C","Critical"),
            new KeyValuePair<string, string>("MC","Mission Critical"),
        };

        static BugsController()
        {

            bugs.Add(new Bug { Id = 1, Name = "Server communication failure", IsClosed = false });
            bugs.Add(new Bug { Id = 2, Name = "User actions not recognized", IsClosed = true });
        }
        // GET: Bugs
        public ActionResult Index()
        {
            var viewModel = new BugViewModel
            {
                ClosedCount = bugs.Count(bug => bug.IsClosed),
                Bugs = bugs,
                NewBug = new NewBugModel() { SeverityCodes = this.SeverityCodes }
               
            };
           
         
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult New(NewBugModel newBugData)
        {
            var currentBugId = bugs.Aggregate(0, (result, bug) => result > bug.Id ? result : bug.Id) + 1;
            var newBug = new Bug
            {
                Id = currentBugId,
                Name = newBugData.Name,
                IsClosed = newBugData.IsClosed
            };
            bugs.Add(newBug);
            if (!this.Request.IsAjaxRequest()){
               
                return RedirectToAction("Index");
            }
            return PartialView("_Details", newBug);
        }

        public ActionResult Toggle(int Id)
        {
            var bug = bugs.First(b => b.Id == Id);
            if (bug != null)
            {
                bug.IsClosed = !bug.IsClosed;
            }
            if (!this.Request.IsAjaxRequest())
            {

                return RedirectToAction("Index");
            }
            return PartialView("_Details", bug);
            //return RedirectToAction("Index");

        }

    }
    public interface IBug
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsClosed { get; set; }
    }
    public class Bug : IBug
    {
        public int Id
        {
            get; set;
        }

        public bool IsClosed
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}