using DependencyInjectionSample.GuidGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.GuidGenerator.Services.Rules
{
    public interface IGuidRule
    {
        bool Check(IndexViewModel indexViewModel);
    }
    public class GuidRule1 : IGuidRule
    {
        public bool Check(IndexViewModel indexViewModel)
        {
            //rule 1 için comment
            return true;
        }
    }
    public class GuidRule2 : IGuidRule
    {
        public bool Check(IndexViewModel indexViewModel)
        {
            //rule 2 için comment
            return true;
        }
    }
    public class GuidRule3 : IGuidRule
    {
        public bool Check(IndexViewModel indexViewModel)
        {
            //rule 3 için comment
            return true;
        }
    }

}
