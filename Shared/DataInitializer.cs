using Bogus;
using System;
using System.Linq;
using WebApi.Models;

namespace WebApi.Shared
{
    public class DataInitializer
    {
        public static void Initialize(TodoContext toDoContext)
        {
            Randomizer.Seed = new Random(392183341);

            if (toDoContext.TodoItems.Count() == 0)
            {
                // Create new ToDo Items only if the database is empty
                var testToDoItems = new Faker<TodoItem>()
                    .RuleFor(t => t.Name, t => t.Lorem.Sentence(3 , 6))
                    .RuleFor(t => t.IsComplete, t => t.Random.Bool())
                    .RuleFor(t => t.Secret, t => t.Random.Word());
                var todoItems = testToDoItems.Generate(8);

                foreach (TodoItem t in todoItems)
                {
                    toDoContext.TodoItems.Add(t);
                }
                toDoContext.SaveChanges();
            }
        }
    }
}