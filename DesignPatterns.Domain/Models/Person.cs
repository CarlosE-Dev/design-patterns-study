using System;

namespace DesignPatterns.Domain.Models
{
    public class Person
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Document { get; set; }
    }
}
