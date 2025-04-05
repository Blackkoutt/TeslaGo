using AutoMapper;
using TeslaGoAPI.Logic.Mapper.Extensions;

namespace TeslaGoAPI.Extensions
{
    public static class AppExtensionsMapper
    {
        public static void UseAutoMapper(this IApplicationBuilder app)
        {
            var mapper = app.ApplicationServices.GetService<IMapper>();
            if (mapper != null)
            {
                MappingExtensions.Configure(mapper);
            }
        }
    }
}
