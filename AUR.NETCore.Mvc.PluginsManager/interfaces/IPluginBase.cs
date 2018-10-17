using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUR.NETCore.Mvc.PluginsManager.interfaces
{
    public interface IPluginBase
    {
        string Name { get; }
        ViewsTypeResouces ViewsTypeResouces { get; }
        ControllerTypeResouces ControllerTypeResouces { get; }
        void PluginConfigure(IApplicationBuilder app, IHostingEnvironment env);
        void PluginConfigureServices(IServiceCollection services);
    }


    public enum ViewsTypeResouces
    {
        Assembly,
        Embedded,
        None
    }
    public enum ControllerTypeResouces
    {
        Assembly,
        None
    }
}
