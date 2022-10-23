using mail_service;

namespace MailServiceTest;

public class ReminderTest
{
    private readonly Reminder _sut;

    public ReminderTest()
    {
        _sut = new Reminder();
    }

    [Test]
    public void TestPersonHasNoBirthday()
    {
        Assert.False(_sut.PersonHasBirthday(GetPerson()));
    }

    [Test]
    public void TestPersonHasBirthday()
    {
        Person person = GetPerson();
        person.BirthDay = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        Assert.True(_sut.PersonHasBirthday(person));
    }

    [Test, TestCaseSource(nameof(GetPersonData))]
    public void TestPersonListIsNotNull(Person person)
    {
        Assert.NotNull(person);
    }

    [Test]
    public void TestListOfContactsBirthDayReminderHasElements()
    {
        Assert.That(_sut.GetListOfContactsBirthDayReminder(GetPersonData().ToList())!.Count, Is.GreaterThan(0));
    }

    [Test]
    public void TestContactListIsSorted()
    {
        Assert.That(_sut.SortContactsByBirthday(GetPersonData().ToList()).First().BirthDay,
            Is.EqualTo(DateOnly.FromDateTime(DateTime.Today.AddDays(-1))));
    }

    private static Person GetPerson()
    {
        return new Person("Alice", "aliceL", "alic@g.com", DateOnly.FromDateTime(DateTime.Today));
    }

    private static IEnumerable<Person> GetPersonData()
    {
        var list = new List<Person>
        {
            new("Alice", "aliceL", "alic@g.com", DateOnly.FromDateTime(DateTime.Today)),
            new("Bob", "BobL", "bob@g.com", DateOnly.FromDateTime(DateTime.Today).AddDays(1)),
            new("Eva", "EvaL", "eva@g.com", DateOnly.FromDateTime(DateTime.Today.AddDays(-1)))
        };
        return list;
    }
}