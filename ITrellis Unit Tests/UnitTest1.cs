using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChrisTrent_ITrellis.Models;
using System.Linq;
using System.Collections.Generic;
using ChrisTrent_ITrellis.Controllers;

namespace ITrellis_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        //mocking database actions with lists.

        [TestMethod]
        public void TestCreateTodo_Sucess()
        {
            Todo todo = new Todo();
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            Assert.IsNotNull(todo);
        }

        [TestMethod]
        public void TestAddTodo_Sucess()
        {
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            List<Todo> Todos = new List<Todo>();
            Todos.Add(todo);
            Todo tempTodo = new Todo();
            foreach (var item in Todos)
                if (item == todo)
                    tempTodo = item;
            Assert.AreEqual(todo, tempTodo);
        }

        [TestMethod]
        public void DeleteTodo_SucessItemRemoved()
        {
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            List<Todo> Todos = new List<Todo>();
            Todos.Add(todo);
            Todos.Remove(todo);
            bool isInList = false;
            foreach (var item in Todos)
                if (item == todo)
                    isInList = true;

            Assert.IsFalse(isInList);
        }

        [TestMethod]
        public void DeleteTodo_FailItemNotRemoved()
        {
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            List<Todo> Todos = new List<Todo>();
            Todos.Add(todo);
            bool isInList = false;
            foreach (var item in Todos)
                if (item == todo)
                    isInList = true;
            Assert.IsTrue(isInList);

        }

        [TestMethod]

        public void EditTodo_SucessItemEdited()
        {
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            List<Todo> Todos = new List<Todo>();
            Todos.Add(todo);
            bool isModified = false;

            for (int i = 0; i < Todos.Count; i++)
            {
                Todos[i].moreDetails = "Modified";
                isModified = true;
            }
              
            Assert.IsTrue(isModified);
        }

        [TestMethod]
        public void EditTodo_SucessNotEdited()
        {
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";
            List<Todo> Todos = new List<Todo>();
            Todos.Add(todo);
            bool isModified = false;
            Assert.IsFalse(isModified);
        }

        [TestMethod]
       public void TestDeadlineDateFunction_SucessBeforeDeadline()
        {
            TodoController controller = new TodoController();
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now;
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";

            var returnVal = controller.isPassedDeadline(todo.deadLineDate);
            Assert.IsFalse(returnVal);
        }

        [TestMethod]
        public void TestDeadLineDateFunction_SucessAfterDeadline()
        {
            TodoController controller = new TodoController();
            Todo todo = new Todo();
            todo.ID = 1;
            todo.deadLineDate = DateTime.Now.Date.AddDays(10);
            todo.isComplete = false;
            todo.moreDetails = "More Details";
            todo.toDo_Item = "Wash Face";

            var returnVal = controller.isPassedDeadline(todo.deadLineDate);
            Assert.IsTrue(returnVal);
        }
    }
}
