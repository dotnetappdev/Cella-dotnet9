using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cella.API
{
    public static class MiddlewareRegistrationExtensions
    {
        // Extension method to add CORS configuration
        public static void AddCorsPolicies(this IApplicationBuilder app)
        {

        }

        // Extension method to add Swagger UI
        public static void AddSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;  // Serve Swagger at the root
            });
        }

        public static void AddAuthorizationMiddleware(this IApplicationBuilder app)
        {
            app.UseAuthorization();
      //      app.MapGroup("/admin").MapIdentityApi<ApplicationUser>();

        }

    }
}

