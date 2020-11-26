using Bogus;
using System;
using System.Linq;
using WebApi.Models;

namespace WebApi.Shared
{
    public class DataInitializer
    {
        public static void Initialize(PersonContext personContext)
        {
            Randomizer.Seed = new Random(392183341);

            if (personContext.People.Count() == 0)
            {
                // Create new people only if the database is empty
                var testPeople = new Faker<WebApi.Models.Person>()
                    .RuleFor(p => p.FirstName, p => p.Name.FirstName())
                    .RuleFor(p => p.LastName, p => p.Name.LastName())
                    .RuleFor(p => p.DateOfBirth, p => p.Date.Past(60, new DateTime(2010, 12, 31)))
                    .RuleFor(p => p.Gender, p => p.PickRandom<Gender>());
                var people = testPeople.Generate(8);

                foreach (WebApi.Models.Person p in people)
                {
                    personContext.People.Add(p);
                }
                personContext.SaveChanges();
            }
        }
    }
}