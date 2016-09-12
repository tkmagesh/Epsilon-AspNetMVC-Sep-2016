using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _02_Greeting_MVC_App.Controllers;
using Moq;
namespace _02_Greeting_MVC_App_Tests
{
   /* public class FakeDateServiceForMorning : IDateService
    {
        public DateTime GetDateTime()
        {
            return new DateTime(2016, 9,12,9,0,0);
        }
    }

    public class FakeDateServiceForAfternoon : IDateService
    {
        public DateTime GetDateTime()
        {
            return new DateTime(2016, 9, 12, 15, 0, 0);
        }
    }

    public class FakeGreeter : IGreeter
    {
        public string Name { get; set; }
        public string GreetMessage { get; set; }

        public bool IsGreetInvoked { get; set; }

        
        public FakeGreeter()
        {
            Name = "Dummy Name";
            this.IsGreetInvoked = false;
            
        }
        public void Greet()
        {
            this.IsGreetInvoked = true;
            this.GreetMessage = "Dummy Message";
        }
    }*/
    [TestClass]
    public class GreeterControllerTests
    {
        [TestMethod]
        public void Returns_Morning_View_Before_12()
        {
            //var morningDateService = new FakeDateServiceForMorning();
            var morningDateServiceMoq = new Moq.Mock<IDateService>();
            morningDateServiceMoq.Setup(service => service.GetDateTime()).Returns(new DateTime(2012, 9, 12, 9, 0, 0));
            var morningDateService = morningDateServiceMoq.Object;

            //var greeter = new FakeGreeter();
            var greeterMoq = new Moq.Mock<IGreeter>();

            var greeter = greeterMoq.Object;
            var greeterController = new GreeterController(morningDateService, greeter);

            var result = greeterController.Greet("Magesh");

            Assert.AreEqual("MorningView", result.ViewName);
        }

        [TestMethod]
        public void Sends_GreetMessage_From_Greeter_To_View()
        {
            var morningDateServiceMoq = new Moq.Mock<IDateService>();
            morningDateServiceMoq.Setup(service => service.GetDateTime()).Returns(new DateTime(2012, 9, 12, 9, 0, 0));
            var morningDateService = morningDateServiceMoq.Object;

            var greeterMoq = new Moq.Mock<IGreeter>();

            var greeter = greeterMoq.Object;
            greeterMoq.SetupGet(greeterObj => greeterObj.GreetMessage).Returns("Dummy Message");

            var greeterController = new GreeterController(morningDateService, greeter);
            var expectedResult = "Dummy Message";

            var result = greeterController.Greet("Magesh");

            greeterMoq.Verify(greeterObj => greeterObj.Greet(), Times.AtLeastOnce);
            Assert.AreEqual(expectedResult, result.ViewData["message"]);
        }
    }
}
