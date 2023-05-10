using System;
using ICanHazDadJoke.Middlewares;

namespace ICanHazDadJoke.Extensions
{
    internal static class Configure
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            return app;
        }
    }
}

