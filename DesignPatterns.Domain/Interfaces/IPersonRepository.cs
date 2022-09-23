using DesignPatterns.Domain.Models;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Guid Create(Person person);
        IEnumerable<Person> GetAll();
        Person GetById(Guid id);
        void Update(Guid id, Person person);
        void Delete(Person person);
    }
}
