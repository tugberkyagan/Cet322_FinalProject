using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cet322_FinalProject.Data;
using Cet322_FinalProject.Models;

namespace Cet322_FinalProject.Controllers
{
    public class SubTodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubTodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubTodo
        public async Task<IActionResult> Index()


        {
            var subTodoList = await _context.SubTodo.Include("Todo").ToListAsync();

            return View(subTodoList);
        }

        // GET: SubTodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTodo = await _context.SubTodo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTodo == null)
            {
                return NotFound();
            }

            return View(subTodo);
        }

        // GET: SubTodo/Create
        public IActionResult Create()
        {
            ViewData["TodoId"] = new SelectList(_context.Todo, "Id", "Title");
            return View();
        }

        // POST: SubTodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TodoId,isComplete")] SubTodo subTodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subTodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subTodo);
        }

        // GET: SubTodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["TodoId"] = new SelectList(_context.Todo, "Id", "Title");

            if (id == null)
            {
                return NotFound();
            }

            var subTodo = await _context.SubTodo.FindAsync(id);
            if (subTodo == null)
            {
                return NotFound();
            }



            return View(subTodo);
        }

        // POST: SubTodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,TodoId,isComplete")] SubTodo subTodo)
        {
            if (id != subTodo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subTodo);

                    var todos = await _context.Todo.ToListAsync();
                    var todo = todos.Where(x => x.Id == subTodo.TodoId).FirstOrDefault();
                    var unCompleteCount = 0;

                    unCompleteCount = todo.SubTodos.Where(x => x.isComplete == false).Count();

                    if (todo.SubTodos != null)
                    {
                        if (unCompleteCount == 0)
                            todo.isComplete = true;
                        if (unCompleteCount > 0)
                            todo.isComplete = false;
                    }


                    _context.Update(todo);

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTodoExists(subTodo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subTodo);
        }

        // GET: SubTodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTodo = await _context.SubTodo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTodo == null)
            {
                return NotFound();
            }

            return View(subTodo);
        }

        // POST: SubTodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subTodo = await _context.SubTodo.FindAsync(id);
            _context.SubTodo.Remove(subTodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubTodoExists(int id)
        {
            return _context.SubTodo.Any(e => e.Id == id);
        }
    }
}
