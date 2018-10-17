using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using AUR.NETCore.Mvc.PluginsManager.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AUR.NETCore.Mvc.PluginsManager
{

    public class PluginsManager<T> : Dictionary<string, T> where T : IPluginBase
    {
        private string _PluginsFolder;
        public string PluginsFolder { get { return _PluginsFolder; } }

        public PluginsManager(string PluginsFolder)
        {
            _PluginsFolder = PluginsFolder;
        }

        public void Load(IServiceCollection services)
        {
            if (Directory.Exists(PluginsFolder))
            {
                var aa = Directory.GetFiles(PluginsFolder, "*.dll").Where((x) => !x.Contains(".Views.dll"));
                foreach (string dlls in aa)
                {
                    Assembly a = Assembly.LoadFile(dlls);
                    TypeInfo c;
                    try
                    {
                        c = a.DefinedTypes.Where((b) => b.ImplementedInterfaces.Where(bb => bb == typeof(T)).Count() > 0).First();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("PluginsManager: " + dlls + " not contains a definition for " + typeof(T).Name);
                    }
                    if (c != null)
                    {
                        T Plugin = (T)a.CreateInstance(c.FullName);
                        this.Add(dlls, Plugin);
                    }
                    else
                        throw new Exception("PluginsManager: " + dlls + " not contains a definition for " + typeof(T).Name);
                }
            }
            else
                throw new Exception("PluginsManager: no Plugins folder found");

            foreach (var a in this)
            {
                switch (a.Value.ViewsTypeResouces)
                {
                    case ViewsTypeResouces.Assembly:
                        string ViewAssembypath = a.Key.Replace(".dll", ".Views.dll");
                        if (File.Exists(ViewAssembypath))
                        {
                            services.AddMvc().ConfigureApplicationPartManager(apm =>
                            {
                                foreach (var b in new CompiledRazorAssemblyApplicationPartFactory().GetApplicationParts(AssemblyLoadContext.Default.LoadFromAssemblyPath(ViewAssembypath)))
                                    apm.ApplicationParts.Add(b);
                            });
                        }
                        else
                            throw new Exception("PluginsManager: no Plugin View Assembly found: " + ViewAssembypath);
                        break;
                    case ViewsTypeResouces.Embedded:
                        var embeddedFileProvider = new EmbeddedFileProvider(AssemblyLoadContext.Default.LoadFromAssemblyPath(a.Key));
                        services.Configure<RazorViewEngineOptions>(options => { options.FileProviders.Add(embeddedFileProvider); });
                        break;
                    default:
                        break;
                }
                switch (a.Value.ControllerTypeResouces)
                {
                    case ControllerTypeResouces.Assembly:
                        services.AddMvc().ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(new AssemblyPart(AssemblyLoadContext.Default.LoadFromAssemblyPath(a.Key))));
                        break;
                    default:
                        break;
                }
                foreach (var item in this.Select(x => x.Value))
                    item.PluginConfigureServices(services);
            }
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            foreach (var item in this.Select(x => x.Value))
                item.PluginConfigure(app, env);
        }
    }
}
