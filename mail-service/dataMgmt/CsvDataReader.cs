namespace mail_service;

using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

public class CsvDataReader : IDataInterface
{
    private static readonly string CSV_FILE = Constants.CSV_FILE;


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
                var data = csv.GetRecords<Person>().ToList();
                //var dataAsync = csv.GetRecordsAsync<Person>(); 
                return data;
            }
        }
    }
}