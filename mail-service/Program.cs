// See https://aka.ms/new-console-template for more information

using mail_service;

Console.WriteLine("Hello World!");
CsvDataReader s = new CsvDataReader(); 
Console.WriteLine(s.getData());
Mailer.sendEmail();
