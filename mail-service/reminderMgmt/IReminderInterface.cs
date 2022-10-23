namespace mail_service;

public interface IReminderInterface
{
        void IntervalBirthDayCheck(List<Person> listOfContacts); 
        void SendReminder(List<Person> listOfContacts);
}