using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_GreetingApp;

namespace _01_GreetingApp_Tests
{
    public class FakeDateServiceForMorning : IDateService
    {
        public DateTime GetDateTime()
        {
            return new DateTime(2016, 9, 12, 9 , 0 , 0);
        }
    }

    public class FakeDateServiceForEvening : IDateService
    {
        public DateTime GetDateTime()
        {
            return new DateTime(2016, 9, 12, 17, 0, 0);
        }
    }

    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Returns_GoodMorning_When_Greeted_Before_12()
        {
            //Arrange
            var name = "Magesh";
            var morningDateService = new FakeDateServiceForMorning();
            var greeter = new Greeter(morningDateService);
            var expectedMessage = "Hi Magesh, Good Morning!";
            
            //Act
            greeter.Name = name;
            greeter.Greet();

            //Assert
            Assert.AreEqual(expectedMessage, greeter.GreetMessage);
        }

        [TestMethod]
        public void Returns_GoodEvening_When_Greeted_After_12()
        {
            //Arrange
            var name = "Magesh";
            var eveningDateService = new FakeDateServiceForEvening();
            var greeter = new Greeter(eveningDateService);
            var expectedMessage = "Hi Magesh, Good Afternoon!";

            //Act
            greeter.Name = name;
            greeter.Greet();

            //Assert
            Assert.AreEqual(expectedMessage, greeter.GreetMessage);
        }
    }
}
