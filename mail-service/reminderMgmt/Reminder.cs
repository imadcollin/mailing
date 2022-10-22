namespace mail_service.messagingMgmt;

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

    public bool PersonHasBrithDay(Person person)
    {
        if (person != null)
        {
            return person.BirthDay == Today.AddDays(-1);
        }

        return false;
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
            return contactList.FindAll(x => x.BirthDay == Today.AddDays(-1));
        }

        return null;
    }

    private bool ContactsHasBirthday(List<Person> contactList)
    {
        if (Util.AnyAndNotNull(contactList))
        {
            return GetListOfContactsBirthDayReminder(contactList).Count > 0;
        }

        return false;
    }

    public void IntervalBirthDayCheck(List<Person> listOfContacts)
    {
        //today -> looop -> has any birthday? -> send reminder. 
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        System.Timers.Timer timer = new(interval: 1000);
        timer.Elapsed += (sender, e) => notifyIfAnyReminder(listOfContacts);
        timer.Start();

        Console.ReadLine(); // To make sure the console app keeps running.
        System.Threading.Thread.Sleep(100000);

        timer.Dispose();
    }

    private void notifyIfAnyReminder(List<Person> listOfContacts)
    {
        // TODO::
    }
}