namespace mail_service.messagingMgmt;

public interface IMessageInterface
{
    private static readonly DateOnly Today = DateOnly.FromDateTime(DateTime.Now);

    void SendMessage(Person person);

   public static bool PersonHasBrithDay(Person person)
    {
            if (person != null)
            {
                return person.BirthDay == Today.AddDays(-1);
            }
            return false;
        }
    
}