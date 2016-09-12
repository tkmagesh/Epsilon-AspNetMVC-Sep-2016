using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeter = new Greeter(new DateService());
            Console.WriteLine("Enter the name");
            greeter.Name = Console.ReadLine();
            greeter.Greet();
            Console.WriteLine(greeter.GreetMessage);
            Console.ReadLine();
        }
    }

    public class Greeter
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
