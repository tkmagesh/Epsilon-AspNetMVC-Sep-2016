using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace TodoManagerApp.Models
{
    public interface ITodoRepository
    {
        void Add(Todo todo);
        IEnumerable<Todo> Items { get; }

        void Add(string todoName);
    }

    public class TodoRepository : ITodoRepository
    {
        private IList<Todo> _todos = new List<Todo>();

        public void Add(Todo todo)
        {
            if (todo.Id != 0) return;
            todo.Id = _todos.Any() ? _todos.Aggregate(0, (result, item) => result > item.Id ? result : item.Id) + 1 : 1;
            _todos.Add(todo);
        }

        public void Add(string todoName)
        {
            Add(new Todo {Name = todoName});
        }

        public IEnumerable<Todo> Items
        {
            get { return _todos; }
        } 
        
    }
}