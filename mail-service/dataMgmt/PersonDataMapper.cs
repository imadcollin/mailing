using CsvHelper.Configuration;

namespace mail_service;

public class PersonDataMapper : ClassMap<Person>
{
    public PersonDataMapper()
    {
        Map(m => m.FirstName).Name(Constants.FirstName);
        Map(m => m.LastName).Name(Constants.LastName);
        Map(m => m.Email).Name(Constants.Email);
        Map(m => m.BirthDay).Name(Constants.BirthDay);
    }
}