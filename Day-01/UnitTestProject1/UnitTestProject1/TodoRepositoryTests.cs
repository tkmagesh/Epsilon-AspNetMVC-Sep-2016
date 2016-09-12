using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoManagerApp.Models;

namespace TodoManagerAppTests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void Id_Is_Incremented_When_Adding_A_New_Todo()
        {
            //Arrange
            var itemToAdd = new Todo {Name = "Watch a movie"};
            var todos = new TodoRepository();

            //Act
            todos.Add(itemToAdd);

            //Assert
            Assert.AreEqual(1, itemToAdd.Id);
        }

        [TestMethod]
        public void Id_Is_Incremented_When_Adding_A_New_Todo_2()
        {
            //Arrange
            var itemToAdd = new Todo { Name = "Watch a movie" };
            var anotherItemToAdd = new Todo {Name = "Fix that bug"};

            var todos = new TodoRepository();
            

            
            //Act
            todos.Add(itemToAdd);
            todos.Add(anotherItemToAdd);

            //Assert
            Assert.AreEqual(2, anotherItemToAdd.Id);
        }

        [TestMethod]
        public void Todos_Count_is_Incremented_When_Adding_A_Todo()
        {
            //Arrange
            var itemToAdd = new Todo { Name = "Watch a movie" };
            var anotherItemToAdd = new Todo { Name = "Fix that bug" };

            var todos = new TodoRepository();

            //Act
            todos.Add(itemToAdd);
            todos.Add(anotherItemToAdd);
            //Assert
            Assert.AreEqual(2, todos.Items.Count());
        }

    }


}
