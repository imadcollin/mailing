using mail_service;

namespace TestProject1;

public class Tests
{
    private readonly Reminder _reminder; 
    [SetUp]
    public void Setup()
    {
        Reminder reminder = new Reminder(); 
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}