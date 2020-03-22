﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DependencyInjectionSample.GuidGenerator.Models;
using DependencyInjectionSample.GuidGenerator.Services;
using DependencyInjectionSample.GuidGenerator.Services.Rules;

namespace DependencyInjectionSample.GuidGenerator.Controllers
{
    public class HomeController : Controller
    {

        ILogger<HomeController> _logger;
        ISingletonGuidGenerator _singletonGuidGenerator;
        IScopedGuidGenerator _scopedGuidGenerator;
        ITransientGuidGenerator _transientGuidGenerator;
        public HomeController(ILogger<HomeController> logger,
            ISingletonGuidGenerator singletonGuidGenerator,
            IScopedGuidGenerator scopedGuidGenerator,
            ITransientGuidGenerator transientGuidGenerator)
        {
            _logger = logger;
            _singletonGuidGenerator = singletonGuidGenerator;
            _scopedGuidGenerator = scopedGuidGenerator;
            _transientGuidGenerator = transientGuidGenerator;

        }

        public IActionResult Index(
            [FromServices]ISingletonGuidGenerator singletonGuidGenerator,
            [FromServices]IScopedGuidGenerator scopedGuidGenerator,
            [FromServices]ITransientGuidGenerator transientGuidGenerator,[FromServices] IEnumerable<IGuidRule> guidRules)
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            //Singleton Constractor  ve action  injection için üretilen guid Idler ekleniyor;
            indexViewModel.Singleton.Constructor = _singletonGuidGenerator.Guid;
            indexViewModel.Singleton.Action = singletonGuidGenerator.Guid;
            //Transient Constractor  ve action  injection için üretilen guid Idler ekleniyor;
            indexViewModel.Transient.Constructor = _transientGuidGenerator.Guid;
            indexViewModel.Transient.Action = transientGuidGenerator.Guid;
            //Scoped Constractor  ve action  injection için üretilen guid Idler ekleniyor;
            indexViewModel.Scoped.Constructor = _scopedGuidGenerator.Guid;
            indexViewModel.Scoped.Action = scopedGuidGenerator.Guid;
            foreach (var guidRule in guidRules)
            {
                guidRule.Check(indexViewModel);
            }

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
