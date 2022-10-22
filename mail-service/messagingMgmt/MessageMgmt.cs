namespace mail_service.messagingMgmt;

public class MessageMgmt :IMessageInterface 
{
    private  Mailer _mailer = Mailer.GetInstance();
    
    public void SendMessage(Person person, Message msg)
    {
        _mailer.SendMessage(person,msg);
    }

    public void SendReminder(List<Person> listOfContacts, Message message)
    {
     //   _mailer.SendReminder(listOfContacts,message);
    }
}