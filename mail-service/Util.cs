using Microsoft.Extensions.Configuration;

namespace mail_service;

public static class Util
{
    public static IConfigurationRoot? GetConfig(string filePath)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(filePath).Build();
    }

    public static bool AnyAndNotNull<T>(this IEnumerable<T> source)
    {
        if (source != null && !source.Any())
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        return true;
    }

    public static DateOnly DateOnlyFromDatetime(DateTime dateTime)
    {
        return DateOnly.FromDateTime(dateTime);
    }

    public static bool ValidateDate(string date)
    {
        try
        {
            string[] dateParts = date.Split('/');

            var dateTime = new
                DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));
            return true;
        }
        catch
        {
            return false;
        }
    }
}