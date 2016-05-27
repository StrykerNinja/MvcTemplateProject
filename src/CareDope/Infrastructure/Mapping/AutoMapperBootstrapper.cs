namespace CareDope.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using AutoMapper;

    public class AutoMapperBootstrapper
    {
        private static readonly Lazy<AutoMapperBootstrapper> Bootstrapper = new Lazy<AutoMapperBootstrapper>(InternalInitialize);

        public static void Initialize()
        {
            var bootstrapper = Bootstrapper.Value;
        }

        private AutoMapperBootstrapper()
        {
        }

        private static AutoMapperBootstrapper InternalInitialize()
        {
            var profiles = typeof(AutoMapperBootstrapper)
                .Assembly
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Profile)))
                .Select(Activator.CreateInstance)
                .Cast<Profile>()
                .ToArray();

            Mapper.Initialize(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            return new AutoMapperBootstrapper();
        }
    }
}