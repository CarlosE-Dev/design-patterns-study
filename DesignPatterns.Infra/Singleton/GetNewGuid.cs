using System;

namespace DesignPatterns.Infra.Singleton
{
    public sealed class GetNewGuid
    {
        private static GetNewGuid instance = null;

        public Guid Id { get; } = Guid.NewGuid();

        public static GetNewGuid Instance
        {
            get 
            { 
                if(instance == null )
                    instance = new GetNewGuid();

                return instance;
            }
        }
    }
}
