using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTodoList.Data;
using RazorTodoList.Models;

namespace RazorTodoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorTodoList.Data.RazorTodoListContext _context;

        public IndexModel(RazorTodoList.Data.RazorTodoListContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList States { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TodoStates { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> statesQuery = from m in _context.Todo
                                             orderby m.States
                                             select m.States;

            var todos = from m in _context.Todo
                        select m;

            // ToDo検索欄なにかが入っていれば検索を行う
            if (!string.IsNullOrEmpty(SearchString))
            {
                todos = todos.Where(s => s.TodoName.Contains(SearchString));
            }

            // ステータス選択、Allなら何もしない
            if (!string.IsNullOrEmpty(TodoStates))
            {
                todos = todos.Where(x => x.States == TodoStates);
            }
            States = new SelectList(await statesQuery.Distinct().ToListAsync());
            Todo = await todos.ToListAsync();
        }
    }
}
