using System;

namespace DependencyInjectionSample.GuidGenerator.Services
{
    public interface IGuidGenerator
    {
        public Guid Guid { get;  }
    }

    public interface ISingletonGuidGenerator : IGuidGenerator { }
    public interface IScopedGuidGenerator : IGuidGenerator { }
    public interface ITransientGuidGenerator : IGuidGenerator { }
}
