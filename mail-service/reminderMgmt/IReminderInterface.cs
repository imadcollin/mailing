namespace mail_service.messagingMgmt;

public interface IReminderInterface
{
void IntervalBirthDayCheck(List<Person> listOfContacts); 
        void SendReminder(List<Person> listOfContacts, Message message);

}