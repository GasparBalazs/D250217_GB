using D250217_GB;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Channels;

string PATH = "C:\\Users\\gaspar.balazs\\Desktop\\D250217_GB\\resources\\";
string FILE = "course.txt";
List<Hallgato> hallgatok = new List<Hallgato>();
using StreamReader sr = new StreamReader(PATH+FILE);
while (!sr.EndOfStream)
{
    Hallgato h = new Hallgato(sr.ReadLine()!);
    hallgatok.Add(h);
}

//1.
int f1 = hallgatok.Count();
Console.WriteLine($"Feladat 1.: {f1} hallgató adatait tartalmazza a fájl.");
//2.
double f2 = hallgatok.Average(x => x.Eredmenyek["backend"]);
Console.WriteLine($"Feladat 2.: ");

//3.
Hallgato f3 = hallgatok.MaxBy(x => x.Eredmenyek.Values.Sum())!;
Console.WriteLine($"Feladat 3.: Osztályelső: {f3}");

//4.
double f4 = hallgatok.Count(x => x.Nem) / (double)hallgatok.Count();
Console.WriteLine($"Feladat 4.: Férifak aránya: {f4*100:0}%");

//5.
Hallgato f5 = hallgatok.Where(x => !x.Nem).MaxBy(x => x.Eredmenyek["frontend"] + x.Eredmenyek["backend"])!;
Console.WriteLine($"Feladat 5.: Legjobb női webfejlesztő: {f5}");

//6.
List<Hallgato> f6 = hallgatok.Where(x => x.Befizetes == 2600).ToList();
Console.WriteLine($"Feladat 6.:\n");
foreach (var item in f6)
{
    Console.WriteLine(item);
}
Console.WriteLine("\n");

//7.
Console.WriteLine("Feladat 7.: Kérem adja meg a hallgató nevét: ");
string nev = Console.ReadLine()!;
Hallgato f7 = hallgatok.FirstOrDefault(x => x.Nev == nev)!;

if(f7 == null)
    Console.WriteLine("Nincs ilyen nevű hallgató!");
else {
    List<string> f72 = [];
    if (f7.Eredmenyek["halozat"] < 51)
    {
        f72.Add("hálózat");
    }
    if (f7.Eredmenyek["mobil"] < 51)
    {
        f72.Add("mobil");
    }
    if (f7.Eredmenyek["frontend"] < 51)
    {
        f72.Add("frontend");
    }
    if (f7.Eredmenyek["backend"] < 51)
    {
        f72.Add("backend");
    }

    Console.Write($"{nev} nevű diák ");
    if (f72.Count == 0)
        Console.WriteLine("nem javítóvizsgázik.");
    else
    {
        foreach (var item in f72!)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("nevű tárgyakból bukik.");
    }
}

//8.
int f8 = hallgatok.Count(x => x.Eredmenyek.Values.Any(y => y == 100) && x.Eredmenyek.Values.All(y => y >= 51));
Console.WriteLine($"Feladat 8.: {f8} hallgató legalább egy modulból 100%-ot teljesített, és egyik modulból sem kell javítóvizsgát tennie.");

//9.
Dictionary<string, int> f9 = hallgatok.SelectMany(x => x.Eredmenyek).Where(x => x.Value < 51).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
foreach (var item in f9)
    Console.WriteLine($"{item.Key}: {item.Value} hallgatónak kell javítóvizsgát tennie.");

//10.
List<string[]> f10 = hallgatok.Select(x => x.Nev.Split(' ')).OrderBy(x => x[1]).ToList();
using StreamWriter sw = new StreamWriter(PATH + "hallgatok.txt");

foreach (var item in f10)
    sw.WriteLine($"{item[1]} {item[0]} - {hallgatok.First(x => x.Nev == $"{item[0]} {item[1]}").Eredmenyek.Values.Average()}");
