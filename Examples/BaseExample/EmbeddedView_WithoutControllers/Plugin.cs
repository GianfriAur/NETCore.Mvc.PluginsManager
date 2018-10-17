using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUR.NETCore.Mvc.PluginsManager.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmbeddedView_WithoutControllers
{
    internal class EmbeddedView_WithoutControllers : IPluginBase
    {
        public string Name { get => "EmbeddedView_WithoutControllers"; }
        public ViewsTypeResouces ViewsTypeResouces { get => ViewsTypeResouces.Embedded; }
        public ControllerTypeResouces ControllerTypeResouces { get => ControllerTypeResouces.None; }

        public void PluginConfigure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //
        }

        public void PluginConfigureServices(IServiceCollection services)
        {
            //
        }
    }
}
