using System.Net;
using System.Net.Mail;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace mail_service;

public class Mailer
{
    private static readonly string CONFIG_FILE = "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\mail.json";

    public static void sendEmail()
    {
        var config = getConfig();
        var host = config["Smtp:Host"];
        var port = Convert.ToInt32(config["Smtp:Port"]);
        var username = config["Smtp:Username"];
        var password = config["Smtp:Password"];
        var from = config["Info:From"];
        var to = config["Info:To"];
        var subject = config["Info:Subject"];
        var body = config["Info:Body"];

        var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };
        
        client.Send(from, to, subject, body);
        Console.WriteLine("Email sent");
    }

    private static IConfigurationRoot getConfig()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(CONFIG_FILE).Build();
    }
}