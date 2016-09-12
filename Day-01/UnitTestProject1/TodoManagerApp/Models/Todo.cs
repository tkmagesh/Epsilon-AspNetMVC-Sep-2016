using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoManagerApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public void Toggle()
        {
            this.IsCompleted = !this.IsCompleted;
        }
    }
}