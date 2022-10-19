namespace mail_service;

using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

public class CsvDataReader : IDataInterface
{
    private static readonly string CSV_FILE =
        "C:\\Users\\imadc\\RiderProjects\\mailing\\mail-service\\data\\Friends.csv";


    public IEnumerable<Person> getData()
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            Delimiter = ",",
            NewLine = Environment.NewLine,
        };

        using (var fs = File.Open(CSV_FILE, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            using (var textReader = new StreamReader(fs, Encoding.UTF8))

            using (var csv = new CsvReader(textReader, configuration))
            {
                csv.Context.RegisterClassMap<PersonDataMapper>();
                var data = csv.GetRecords<Person>();
                //var dataAsync = csv.GetRecordsAsync<Person>(); 
                return data;
                /*

                 //await 
                foreach (var person in data)
                {
                    Console.WriteLine(person.FirstName);
                    Console.WriteLine(person.LastName);
                    Console.WriteLine(person.Email);
                    Console.WriteLine(person.BirthDay.ToString(("MM/dd/yyyy")));
                }
 */
            }
        }
    }
}