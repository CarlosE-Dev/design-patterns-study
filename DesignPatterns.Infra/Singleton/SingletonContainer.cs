using System;

namespace DesignPatterns.Infra.Singleton
{
    public class SingletonContainer
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
