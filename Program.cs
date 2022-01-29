using static System.Console;
using System.Xml.Serialization;


Country country = new Country();
country.CountryId = 1;
country.CountryName = "Sri Lanka";

XmlSerializer serializer = new XmlSerializer(typeof(Country));
string filePath = @"E:\country.xml";

FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
serializer.Serialize(fs, country);

fs.Close();

WriteLine("Xml file created");
ReadKey();

[Serializable]
public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
}




