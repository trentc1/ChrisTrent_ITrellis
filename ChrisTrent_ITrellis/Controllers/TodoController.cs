using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChrisTrent_ITrellis.Models;
using System;

namespace ChrisTrent_ITrellis.Controllers
{
    public class TodoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.TodoList.ToList());
        }

        public ActionResult Details(int id)
        {
            if (id == 0) //check to make sure we have a valid ID (note autoincrement when created, should never be 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.TodoList.Find(id); 
            if (todo == null) //check to see if we have returned a valid todo from database.
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        //default view for making a new todo.
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, toDo_Item, deadLineDate, isComplete, moreDetails")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.TodoList.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.TodoList.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, toDo_Item, deadLineDate, isComplete, moreDetails")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified; //set state to modified otherwise system will reject updating with Entity framework. 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.TodoList.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.TodoList.Find(id);
            db.TodoList.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool isPassedDeadline(DateTime deadline)
        {
            return (deadline > DateTime.Now) ? true : false;     
        }
    }
}
