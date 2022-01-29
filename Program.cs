using System.Xml.Serialization;
using static System.Console;


//create data
List<Continent> continents = new();
continents.Add(new Continent
{
    ContinentName = "Africa",
    Countries =
        new List<Country>
        {
            new() {CountryID = 1, CountryName = "Sudan"},
            new() {CountryID = 2, CountryName = "Libya"},
            new() {CountryID = 3, CountryName = "South Africa"}
        }
});

continents.Add(new Continent
{
    ContinentName = "Asia",
    Countries =
        new List<Country>
        {
            new() {CountryID = 4, CountryName = "Russia"},
            new() {CountryID = 5, CountryName = "China"},
            new() {CountryID = 6, CountryName = "India"}
        }
});

continents.Add(new Continent
{
    ContinentName = "Europe",
    Countries =
        new List<Country>
        {
            new() {CountryID = 7, CountryName = "Russia"},
            new() {CountryID = 8, CountryName = "Ukraine"},
            new() {CountryID = 9, CountryName = "France"}
        }
});

continents.Add(new Continent
{
    ContinentName = "North America",
    Countries =
        new List<Country>
        {
            new() {CountryID = 10, CountryName = "Canada"},
            new() {CountryID = 11, CountryName = "United States"},
            new() {CountryID = 12, CountryName = "Mexico"}
        }
});

continents.Add(new Continent
{
    ContinentName = "South America",
    Countries =
        new List<Country>
        {
            new() {CountryID = 13, CountryName = "Brazil"},
            new() {CountryID = 14, CountryName = "Argentina"},
            new() {CountryID = 15, CountryName = "Peru"}
        }
});

XmlSerializer serializer = new XmlSerializer(typeof(List<Continent>));
string filePath = @"E:\country.xml";

FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
serializer.Serialize(fs, continents);

fs.Close();

WriteLine("Xml file created");

//Deserialize

FileStream fileStream2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
List<Continent>? continentsFromFile = serializer.Deserialize(fileStream2) as List<Continent>;
continentsFromFile?.ForEach(c=>c.Countries.ForEach(x=>WriteLine($"Continent{c.ContinentName}, Id: {x.CountryID}, Name: {x.CountryName}")));
WriteLine("\ncontinents.xml deserialized:");
//if (continentsFromFile != null)
//    foreach (Continent cont in continentsFromFile)
//    {
//        WriteLine(cont.ContinentName);
//        foreach (Country country in cont.Countries) Write(country.CountryName + ", ");
//        WriteLine();
//    }

ReadKey();


[Serializable]
public class Country
{
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}


[Serializable]
public class Continent
{
    public string ContinentName { get; set; }
    public List<Country> Countries { get; set; }
}