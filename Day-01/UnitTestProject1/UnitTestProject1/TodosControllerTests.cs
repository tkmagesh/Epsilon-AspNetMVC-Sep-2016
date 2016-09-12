using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoManagerApp.Controllers;
using TodoManagerApp.Models;

namespace TodoManagerAppTests
{
    [TestClass]
    public class TodosControllerTests
    {
        [TestMethod]
        public void Adding_A_New_Todo_Invokes_TodoRepository()
        {
            //Arrange
            var todoRepositoryMockery = new Moq.Mock<ITodoRepository>();
            var todoRepositoryMock = todoRepositoryMockery.Object;

            var sut = new TodosController(todoRepositoryMock);
            var testTodo = "Dummy Task";
            
            //Act
            sut.New(testTodo);

            //Assert
            todoRepositoryMockery.Verify(mockery => mockery.Add(testTodo), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Adding_A_New_Todo_Display_Message_With_todoName()
        {
            //Arrange
            var todoRepositoryMockery = new Moq.Mock<ITodoRepository>();
            var todoRepositoryMock = todoRepositoryMockery.Object;

            var sut = new TodosController(todoRepositoryMock);
            var testTodo = "Dummy Task";

            //Act
            var result = sut.New(testTodo);

            //Assert
            Assert.IsTrue(((string) result.ViewData["message"]).IndexOf(testTodo, System.StringComparison.Ordinal) != -1);
            Assert.AreEqual("AddResult", result.ViewName);
        }

        [TestMethod]
        public void Listing_Returns_Items_From_Repository()
        {
            var todoRepositoryMockery = new Moq.Mock<ITodoRepository>();
            var testList = new Todo[]{} ;
            todoRepositoryMockery.SetupGet(mockery => mockery.Items).Returns(testList);
            var todoRepositoryMock = todoRepositoryMockery.Object;

            var sut = new TodosController(todoRepositoryMock);
            var result = sut.Index();

            Assert.AreSame(testList, result.ViewBag.Todos);
        }
    }
}
