using CsvHelper.Configuration;

namespace mail_service;

public class PersonDataMapper : ClassMap<Person>
{
    public PersonDataMapper()
    {
        Map(m => m.FirstName).Name("first_name");
        Map(m => m.LastName).Name("last_name");
        Map(m => m.Email).Name("email");
        Map(m => m.BirthDay).Name("date_of_birth");
    }
}