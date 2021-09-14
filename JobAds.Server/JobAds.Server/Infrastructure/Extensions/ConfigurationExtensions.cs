namespace JobAds.Server.Infrastructure.Extensions
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuraiton) 
            => configuraiton.GetConnectionString("DefaultConnection");
    }
}
