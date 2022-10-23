// See https://aka.ms/new-console-template for more information

using System.Runtime.Intrinsics.X86;
using mail_service;
using mail_service.messagingMgmt;


//READ DATA 

DoWork();

static void DoWork()
{
    Console.WriteLine("Welcome to the Mail Service!");

    CsvDataReader reader = new CsvDataReader();
    Person person = reader.getData().First();
    List<Person> persons = reader.getData().ToList();

    IMessageInterface messageInterface = new MessageMgmt();
    //messageInterface.SendMessage(person);

    IReminderInterface reminderInterface = new ReminderMgmt();
    reminderInterface.IntervalBirthDayCheck(persons);
    //reminderInterface.SendReminder(persons);
}