using System;
using ICanHazDadJoke.Dto;
using ICanHazDadJoke.Service;
using ICanHazDadJoke.Contract;
using ICanHazDadJoke.Mapping;
using AutoMapper;

namespace ICanHazDadJoke.Extensions
{
    internal static class Register
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services, ICanHazDadJokeConnectionProperties config)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("icanhazdadjoke",
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            services.AddHttpClient("ICanHazDadJoke",httpClient =>
            {
                if(!string.IsNullOrEmpty(config.BaseUrl))
                {
                    httpClient.BaseAddress = new Uri(config.BaseUrl);
                }
                if (!string.IsNullOrEmpty(config.Accept))
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", config.Accept);
                }
                if (!string.IsNullOrEmpty(config.UserAgent))
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", config.UserAgent);
                }
            });

            RegisterDependencies(services);

            RegisterSwagger(services);

            return services;
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiles());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IICanHazDadJokeService,ICanHazDadJokeService>();
        }

    }
}

