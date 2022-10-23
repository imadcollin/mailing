namespace mail_service.messagingMgmt;

public class MessageMgmt : IMessageInterface
{
    private Mailer? _mailer = Mailer.GetInstance();

    public void SendMessage(Person person)
    {
        if (IMessageInterface.PersonHasBrithDay(person))
        {
            _mailer.SendMessage(person);
        }
        else
            throw new Exception("NO message will be sent, Person has no birthday...");
    }
}