using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.GuidGenerator.Models
{
    public class IndexViewModel
    {
        public GuidModel Singleton { get; set; } = new GuidModel();
        public GuidModel Transient { get; set; } = new GuidModel();
        public GuidModel Scoped { get; set; } = new GuidModel();

    }
}
