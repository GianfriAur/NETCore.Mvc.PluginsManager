
using Microsoft.AspNetCore.Hosting;
using AUR.NETCore.Mvc.PluginsManager.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CompiledView_WithoutControllers
{
    internal class CompiledView_WithoutControllers : IPluginBase
    {
        public string Name { get => "CompiledView_WithoutControllers"; }
        public ViewsTypeResouces ViewsTypeResouces { get => ViewsTypeResouces.Assembly; }
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
