using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_Greeting_MVC_App.Controllers
{
    public class GreeterController : Controller
    {
        private readonly IDateService _dateService;
        private readonly IGreeter _greeter;

        //Poor man's dependency injection
        public GreeterController()
        {
            _dateService = new DateService();
            _greeter = new Greeter(_dateService);
        }
        public GreeterController(IDateService dateService, IGreeter greeter)
        {
            _dateService = dateService;
            _greeter = greeter;
        }

        public ViewResult Greet(string name)
        {
            _greeter.Name = name;
            _greeter.Greet();
            var currentHour = _dateService.GetDateTime().Hour;
            var message = _greeter.GreetMessage;
            //decide how to send the message to the view
            this.ViewData["message"] = message;
            var result = _dateService.GetDateTime().Hour < 12 ? View("MorningView") : View("AfternoonView");
            return result;
        }

    }

    public interface IGreeter
    {
        string Name { get; set; }
        string GreetMessage { get; set; }
        void Greet();
    }

    public class Greeter : IGreeter
    {
        public string Name { get; set; }
        public string GreetMessage { get; set; }

        private IDateService _dateService;

        public Greeter(IDateService dateService)
        {
            _dateService = dateService;
        }

        public void Greet()
        {
            var currentHour = _dateService.GetDateTime().Hour;
            if (currentHour < 12)
                this.GreetMessage = string.Format("Hi {0}, Good Morning!", this.Name);
            else
            {
                this.GreetMessage = string.Format("Hi {0}, Good Afternoon!", this.Name);
            }
        }
    }

    public interface IDateService
    {
        DateTime GetDateTime();
    }

    public class DateService : IDateService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
