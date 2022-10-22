namespace mail_service.messagingMgmt;

public interface IMessageInterface
{
    void SendMessage(Person person, Message msg);
}