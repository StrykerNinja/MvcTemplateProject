using CareDope;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace CareDope
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Infrastructure.DependencyResolution;
    using Infrastructure.Mapping;
    using StructureMap;

    public static class StructuremapMvc
    {
        public static StructureMapDependencyScope ParentScope { get; set; }

        public static void End()
        {
            ParentScope.Dispose();
            ParentScope.DisposeParentContainer();
        }

        public static void Start()
        {
            IContainer container = IoC.Container();
            ParentScope = new StructureMapDependencyScope(IoC.Container(), new HttpContextNestedContainerScope());
            DependencyResolver.SetResolver(ParentScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
            AutoMapperBootstrapper.Initialize();
        }
    }

    public class HttpContextNestedContainerScope : INestedContainerScope
    {
        private const string NestedContainerKey = "Nested.Container.Key";

        public IContainer NestedContainer
        {
            get { return (IContainer)(HttpContext.Current != null ? HttpContext.Current.Items[NestedContainerKey] : null); }
            set { HttpContext.Current.Items[NestedContainerKey] = value; }
        }
    }
}