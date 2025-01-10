using Microsoft.AspNetCore.HttpLogging;

namespace AuthService.Api.Extensions
{
    public static class ConfugureHttpLoggingExtension
    {
        public static IServiceCollection ConfigureHttpLogging(this IServiceCollection services)
        {
            return services.AddHttpLogging(options =>
            {
                options.LoggingFields =
                    HttpLoggingFields.Duration |
                    HttpLoggingFields.RequestBody |
                    HttpLoggingFields.RequestProperties |
                    HttpLoggingFields.RequestQuery |
                    HttpLoggingFields.ResponseBody |
                    HttpLoggingFields.ResponseStatusCode;
            });
        }
    }
}