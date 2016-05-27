namespace CareDope.Infrastructure.DependencyResolution
{
    using System.Web.Mvc;
    using CarePath.Domain.Models;
    using MVC;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Pipeline;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                    scan.AssemblyContainingType<DefaultRegistry>();
                    scan.With(new ControllerConvention());
                });
            For<CarePathContext>().Use(() => new CarePathContext("CarePathContext")).LifecycleIs<TransientLifecycle>();
            For<IControllerFactory>().Use<ControllerFactory>();
            //For<ModelValidatorProvider>().Use<FluentValidationModelValidatorProvider>();
            //For<IValidatorFactory>().Use<StructureMapValidatorFactory>();
        }
    }
}