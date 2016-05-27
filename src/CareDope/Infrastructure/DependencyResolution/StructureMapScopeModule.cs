namespace CareDope.Infrastructure.DependencyResolution
{
    using System.Web;
    using StructureMap.Web.Pipeline;

    public class StructureMapScopeModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructuremapMvc.ParentScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.ParentScope.DisposeNestedContainer();
            };
        }
    }
}