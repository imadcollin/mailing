using System.Diagnostics;

namespace mail_service.messagingMgmt;

public class ReminderMgmt:IReminderInterface
{
    private Reminder _reminder = Reminder.GetInstance();
    private Mailer _mailer = Mailer.GetInstance();
    
    public void IntervalBirthDayCheck(List<Person> listOfContacts)
    {
        _reminder.IntervalBirthDayCheck(listOfContacts);
    }

    public void SendReminder(List<Person> listOfContacts, Message message)
    {
       _mailer.SendReminder(listOfContacts,message);
    }
    
}