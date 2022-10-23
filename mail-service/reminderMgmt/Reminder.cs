using mail_service.messagingMgmt;
using Timer = System.Timers.Timer;

namespace mail_service;

public class Reminder
{
    private static readonly DateOnly Today = DateOnly.FromDateTime(DateTime.Now);

    private static Reminder INSTANCE;

    public static Reminder GetInstance()
    {
        if (INSTANCE == null)
        {
            return new Reminder();
        }

        return INSTANCE;
    }

    public List<Person> SortContactsByBirthday(List<Person> contactList)
    {
        contactList.Sort((x, y) => x.BirthDay.CompareTo(y.BirthDay));
        return contactList;
    }

    public List<Person>? GetListOfContactsBirthDayReminder(List<Person> contactList)
    {
        if (Util.AnyAndNotNull(contactList))
        {
            return contactList.FindAll(x => x.BirthDay == Today.AddDays(1));
        }

        return null;
    }

    public bool PersonHasBirthday(Person person)
    {
        if (person != null)
        {
            return person.BirthDay == Today.AddDays(1);
        }

        return false;
    }

    public bool ContactsHasBirthday(List<Person> contactList)
    {
        if (Util.AnyAndNotNull(contactList))
        {
            return GetListOfContactsBirthDayReminder(contactList).Count > 0;
        }

        return false;
    }

    public void IntervalBirthDayCheck(List<Person> listOfContacts)
    {
        Timer timer = new(interval: 1000);
        timer.Elapsed += (sender, e) => notifyIfAnyReminder(listOfContacts, timer);
        timer.Start();
        Console.ReadLine();
        timer = new(interval: 86400000); //One Day.
        timer.Start();
    }

    private void notifyIfAnyReminder(List<Person> listOfContacts, Timer timer)
    {
        Console.WriteLine("Notification");
        if (ContactsHasBirthday(listOfContacts))
        {
            Console.WriteLine("Tomorrow it is someone birthday....");
            timer.Stop();
            timer.Dispose();
        }
    }
}