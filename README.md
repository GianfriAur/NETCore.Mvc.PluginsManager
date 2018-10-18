# NETCore.Mvc.PluginsManager

this library allows to have and manage plugins in the .netCore mvc projects. it is practical to manage the views both compiled in the * .views.dll file and as embedded resources. in addition it also allows you to manage additional controls that may be present in a plugin that adds functionality. in the future it is also necessary to manage the aggintic content that may be present in wwwroot.

use it is easy and comfortable look below for details

### how to start

```c#
using AUR.NETCore.Mvc.PluginsManager;
```

### Constructors

#### Base
```c#
PluginsManager PM = new PluginsManager<interfaces.IPluginBase>("absolutePath of plugin");
```

##### Example
```c#
const string PluginFolder = "Plugins";
static PluginsManager<interfaces.IPluginBase> _Plugins;
public static PluginsManager<interfaces.IPluginBase> Plugins { get { if (_Plugins == null) _Plugins = new PluginsManager<interfaces.IPluginBase>(Path.Combine(AppContext.BaseDirectory, PluginFolder)); return _Plugins; } }
```

#### Load
```c#
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    Plugins.Load(services); // last row
}
```

#### Configure
```c#
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
   //....
    Plugins.Configure(app, env);    // before default route

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");

    });
}
```
### types of configuration

```c#
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
```

### here is an example of a plugin

```c#
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
```

### here is an example of a costum plugin


##### common interface between project and plugin 

```c#
public interface CostumPlugin : IPluginBase
{
    void Do();
    string version { get; }
}
```

##### main project inizialize 

```c#
const string PluginFolder = "Plugins";
static PluginsManager<CostumPlugin> _Plugins;
public static PluginsManager<CostumPlugin> Plugins { get { if (_Plugins == null) _Plugins = new PluginsManager<CostumPlugin>(Path.Combine(AppContext.BaseDirectory, PluginFolder)); return _Plugins; } }
```
##### here is an example of a plugin


```c#
using Microsoft.AspNetCore.Hosting;
using AUR.NETCore.Mvc.PluginsManager.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CompiledView_WithoutControllers
{
    internal class CompiledView_WithoutControllers : CostumPlugin
    {
        public string Name { get => "CompiledView_WithoutControllers"; }
        public string version { get => "v0.1.23"; }
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
        public void Do()
        {
            // my do
        }
    }
}
```
