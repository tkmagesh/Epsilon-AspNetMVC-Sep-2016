using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoManagerApp.Models;

namespace TodoManagerApp.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController()
        {
            _todoRepository = new TodoRepository();
        }

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ViewResult New(string todoName)
        {
            _todoRepository.Add(todoName);
            this.ViewData["message"] = string.Format("[{0}] is successfully added!", todoName);
            return View("AddResult");
        }

        public ViewResult Index()
        {
            ViewBag.Todos = _todoRepository.Items;
            return View();
        }

    }
}
