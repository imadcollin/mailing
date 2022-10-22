using Microsoft.Extensions.Configuration;

namespace mail_service.messagingMgmt;

public static class Util
{
    public static IConfigurationRoot GetConfig(string filePath)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(filePath).Build();
    }
    
    public static bool AnyAndNotNull<T>(this IEnumerable<T> source)
    {
        if (source != null && source.Any())
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        return true;
    }
}