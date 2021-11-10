using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTodoList.Models;

namespace RazorTodoList.Data
{
    public class RazorTodoListContext : DbContext
    {
        public RazorTodoListContext (DbContextOptions<RazorTodoListContext> options)
            : base(options)
        {
        }

        public DbSet<RazorTodoList.Models.Todo> Todo { get; set; }
    }
}
