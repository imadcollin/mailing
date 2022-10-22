using System.Net;
using System.Net.Mail;
using mail_service.messagingMgmt;
using Microsoft.Extensions.Configuration;

namespace mail_service;

public class Mailer : IMessageInterface
{
    private static readonly string CONFIG_FILE =
        "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\messagingMgmt\\mail.json";

    private static Mailer INSTANCE;
    private static SmtpClient _smtpClient;
    private static IConfigurationRoot _config;
    private static string _from;

    public static Mailer GetInstance()
    {
        if (INSTANCE == null)
        {
            return new Mailer();
        }

        return INSTANCE;
    }

    private Mailer()
    {
        _config = Util.GetConfig(CONFIG_FILE);
        _smtpClient = InitSmtpClient();
        _from = getEmail();
    }

    private string getEmail()
    {
        return _config["Info:From"];
    }

    private SmtpClient InitSmtpClient()
    {
        var host = _config["Smtp:Host"];
        var port = Convert.ToInt32(_config["Smtp:Port"]);
        var username = _config["Smtp:Username"];
        var password = _config["Smtp:Password"];

        var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };
        return client;
    }

    public void SendMessage(Person person, Message msg)
    {
        _smtpClient.Send(_from, msg.To, msg.Subject, ConcatFirstname(msg.Body, person.FirstName));
        Console.WriteLine("Email sent");
    }


    public void SendReminder(List<Person> listOfContacts, Message msg)
    {
        if (Util.AnyAndNotNull(listOfContacts))
        {
            if (listOfContacts.Count == 1)
            {
                Person person = listOfContacts.First();
                _smtpClient.Send(_from, msg.To, msg.Subject, ConcatFirstname(msg.Body, person.FirstName));
            }
            else
            {
                listOfContacts.ToList().ForEach(p =>
                    _smtpClient.Send(_from, msg.To, msg.Subject, ConcatFirstname(msg.Body, p.FirstName)));
            }
        }
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