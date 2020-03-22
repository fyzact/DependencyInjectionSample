using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.GuidGenerator.Services
{
    public class GuidGenerator : ITransientGuidGenerator,ISingletonGuidGenerator,IScopedGuidGenerator
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}
