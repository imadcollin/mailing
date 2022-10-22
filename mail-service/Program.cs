// See https://aka.ms/new-console-template for more information

using System.Runtime.Intrinsics.X86;
using mail_service;
using mail_service.messagingMgmt;

Console.WriteLine("Hello World!");
CsvDataReader s = new CsvDataReader();

//    Console.WriteLine(s.getData().FirstOrDefault().FirstName);


//new Mailer().SendMessage(s.getData().First().FirstName);

//Reminder.PersonHasBrithDay(s.getData().ToList().First());
ReminderMgmt reminderMgmt = new ReminderMgmt();
reminderMgmt.IntervalBirthDayCheck(s.getData().ToList());
