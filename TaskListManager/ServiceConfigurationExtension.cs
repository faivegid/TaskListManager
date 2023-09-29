using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskListManager.Shared.Responses;

namespace TaskListManager
{
    public static class ServiceConfigurationExtension
    {
        /// <summary>
        /// Configures how validation is handle for request body
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(x => x.Key, x => string.Join(Environment.NewLine, x.Value.Errors.Select(e => e.ErrorMessage)));

                    var response = ApiResponse.Error(JsonConvert.SerializeObject(errors));
                    return new BadRequestObjectResult(response);
                };
            });
        }

    }
}
