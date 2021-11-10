using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTodoList.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public string States { get; set; }

        [DataType(DataType.Date)]
        public DateTime TodoDate { get; set; }

    }
}
