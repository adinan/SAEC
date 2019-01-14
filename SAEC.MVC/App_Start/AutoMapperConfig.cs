using System;
using System.Linq;
using AutoMapper;
using WebGrease.Css.Extensions;
using System.Reflection;

namespace SAEC.MVC
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(AddProfile);
        }

        private static void AddProfile(IMapperConfigurationExpression config)
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => typeof(Profile).IsAssignableFrom(p))
                .ForEach(profile =>
                {
                    config.AddProfile((Profile)Activator.CreateInstance(profile));
                });
        }
    }
}