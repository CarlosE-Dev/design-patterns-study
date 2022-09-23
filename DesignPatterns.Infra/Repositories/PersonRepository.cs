using DesignPatterns.Domain.Interfaces;
using DesignPatterns.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // this list should works like a DB Mock, used for CRUD
        private readonly IList<Person> persons = new List<Person>();

        public Guid Create(Person person)
        {
            persons.Add(person);
            return person.Id;
        }

        public void Delete(Person person)
        {
            persons.Remove(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return persons.ToList();
        }

        public Person GetById(Guid id)
        {
            var person = persons.SingleOrDefault(p => p.Id == id);
            return person;
        }

        public void Update(Guid id, Person person)
        {
            var currentModel = persons.SingleOrDefault(p => p.Id == id);
            currentModel.FirstName = person.FirstName;
            currentModel.LastName = person.LastName;
            currentModel.Age = person.Age;
            currentModel.Document = person.Document;
        }
    }
}
