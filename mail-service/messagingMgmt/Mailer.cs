using System.Net;
using System.Net.Mail;
using mail_service.messagingMgmt;
using Microsoft.Extensions.Configuration;

namespace mail_service;

public class Mailer : IMessageInterface
{
    private static readonly string ConfigFile = Constants.CONFIG_FILE;
    private static Mailer? Instance = null;
    private static SmtpClient? _smtpClient;
    private static IConfigurationRoot? _config;
    public static Mailer? GetInstance()
    {
        if (Instance == null)
        {
            return new Mailer();
        }

        return Instance;
    }
    private Mailer()
    {
        _config = Util.GetConfig(ConfigFile);
        _smtpClient = InitSmtpClient();
    }
    private SmtpClient InitSmtpClient()
    {
        var host = _config[Constants.Smtp_Host];
        var port = Convert.ToInt32(_config[Constants.Smtp_Port]);
        var username = _config[Constants.Stmp_User];
        var password = _config[Constants.Stmp_Pass];

        var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };
        return client;
    }
    public void SendMessage(Person person)
    {
        Message msg = BuildMessage(person);
        _smtpClient.Send(msg.From, person.Email, msg.Subject, msg.Body);
        Console.WriteLine("Email sent");
    }
    private Message BuildMessage(Person person)
    {
        return new Message(_config[Constants.Info_From], person.Email, _config[Constants.Info_Subject],
            GetBody("Happy birthday, dear"
                , person.FirstName));
    }
    public void SendReminder(List<Person> listOfContacts)
    {
        if (Util.AnyAndNotNull(listOfContacts))
        {
            if (listOfContacts.Count == 1)
            {
                Message? msg = BuildReminderMsg(listOfContacts);
                _smtpClient?.Send(msg.From, msg.To, msg.Subject, (msg.Body));
                Console.WriteLine("Reminder sent");
            }
            else
            {
                foreach (Person unused in listOfContacts)
                {
                    Message? msg = BuildReminderMsg(listOfContacts);
                    _smtpClient?.Send(msg.From, msg.To, msg.Subject, msg.Body);
                    Console.WriteLine("Reminder sent");
                }
            }
        }
    }
    private Message? BuildReminderMsg(List<Person> persons)
    {
        string body = "";
        if (persons.Count == 1)
        {
            body = BuildSingleReminderBody(persons);
            return new Message(_config[Constants.Info_From], persons.FirstOrDefault()?.Email,
                _config[Constants.Reminder_Subject], body);
        }

        body = BuildManyReminderBody(persons);
        foreach (Person person in persons)
        {
            return new Message(_config[Constants.Info_From], person.Email, _config[Constants.Reminder_Subject],
                body);
        }
        return null;
    }
    private static string BuildSingleReminderBody(List<Person> persons)
    {
        return
            $"Today is  {persons.FirstOrDefault()?.FirstName} {persons.FirstOrDefault()?.LastName} s birthday Don't forget to send him a message !";
    }
    private string BuildManyReminderBody(List<Person> persons)
    {
        return $"Today is  {GetFullNames(persons)}s birthday Don't forget to send them a message !";
    }
    private static string GetFullNames(List<Person> persons)
    {
        string[] names = new string[persons.Count];
        for (int i = 0; i < persons.Count; i++)
        {
            names[i] = ($"{persons[i].LastName}   {persons[i].FirstName}");
        }
        return string.Join(", ", names);
    }
    private static string GetBody(string body, string firstname)
    {
        if (!String.IsNullOrEmpty(body) && !String.IsNullOrEmpty(firstname))
        {
            return string.Concat(body, " ", firstname, " !");
        }

        return "";
    }
}