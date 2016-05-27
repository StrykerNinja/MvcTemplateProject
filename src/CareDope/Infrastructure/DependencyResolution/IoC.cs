namespace CareDope.Infrastructure.DependencyResolution
{
    using System;
    using StructureMap;

    public static class IoC
    {
        private static readonly Lazy<IContainer> _container = new Lazy<IContainer>(() => new Container(c => c.AddRegistry<DefaultRegistry>()));

        public static IContainer Container()
        {
            return _container.Value;
        }
    }
}