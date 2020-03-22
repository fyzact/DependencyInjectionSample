using DependencyInjectionSample.GuidGenerator.Services.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.GuidGenerator.Core.DependencyInjection
{
    public static class GuidRulesExtensions
    {
        public static IServiceCollection AddGuidRules(this IServiceCollection services)
        {
            // Scrutor assembly scanning

            services.Scan(scan => scan
         .FromAssemblyOf<IGuidRule>()
             .AddClasses(classes => classes.AssignableTo<IGuidRule>())
                 .As<IGuidRule>()
                 .WithScopedLifetime());
            return services;
        }

    }
}
