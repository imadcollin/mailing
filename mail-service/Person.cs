namespace mail_service;

public class Person
{
    public Person(string firstName, string lastName, string email, DateOnly birthDay)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDay = birthDay;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public  DateOnly BirthDay { get; set;  }
}