using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AUR.NETCore.Mvc.PluginsManager.interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CompiledView_WithControllers
{
    internal class CompiledView_WithControllers : IPluginBase
    {
        public string Name { get => "CompiledView_WithControllers"; }
        public ViewsTypeResouces ViewsTypeResouces { get => ViewsTypeResouces.Assembly; }
        public ControllerTypeResouces ControllerTypeResouces { get => ControllerTypeResouces.Assembly; }

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
