using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D250217_GB
{
    internal class Hallgato
    {
        public string Nev { get; set; }
        public bool Nem { get; set; }
        public int Befizetes { get; set; }
        public Dictionary<string, int> Eredmenyek { get; set; }
        public override string ToString()
        {
            return $"{Nev} - {(Nem ? "Férfi" : "Nő")} - ${Befizetes} - Eredmények | Hálózat: {Eredmenyek["halozat"]}, Mobil: {Eredmenyek["mobil"]}, Frontend: {Eredmenyek["frontend"]}, Backend: {Eredmenyek["backend"]}";
        }
        public Hallgato(string sor)
        {
            string[] slice = sor.Split(';');
            Nev = slice[0];
            if (slice[1] == "f") Nem = false;
            else Nem = true;
            Befizetes = int.Parse(slice[2]);
            Eredmenyek = new()
            {
                { "halozat", int.Parse(slice[3]) },
                { "mobil", int.Parse(slice[4]) },
                { "frontend", int.Parse(slice[5]) },
                { "backend", int.Parse(slice[6]) }
            };


        }
    }
}
