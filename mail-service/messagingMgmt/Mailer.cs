using System.Net;
using System.Net.Mail;
using mail_service.messagingMgmt;

namespace mail_service;

public class Mailer : IMessageMgmt
{
    private static readonly string CONFIG_FILE =
        "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\messagingMgmt\\mail.json";

    public void SendMessage(string firstName)
    {
        var config = Util.GetConfig(CONFIG_FILE);
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

        client.Send(from, to, subject, ConcatFirstname(body, firstName));
        Console.WriteLine("Email sent");
    }

    private static string ConcatFirstname(string body, string firstname)
    {
        if (!String.IsNullOrEmpty(body) && !String.IsNullOrEmpty(firstname))
        {
            return String.Concat(body, " ", firstname, " !");
        }

        return "";
    }
}