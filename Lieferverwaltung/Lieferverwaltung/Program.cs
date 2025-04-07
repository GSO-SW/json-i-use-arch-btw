namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
            Console.WriteLine(lieferungen.Count);
            ExportJSON();
        }

        static void BeispielobjekteAnlegen()
        {
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 06,22)
                , "HHX05NNW0ZP"
                , "86309"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 09, 4)
                , "GSV18EDC4BR"
                , "91139"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2023, 04, 8)
                , "CQX55KMY5RW"
                , "07708"
            ));
        }

        static void ExportJSON()
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Lieferungen.json")))
            {
                outputFile.WriteLine("{");
                outputFile.WriteLine($"\t\"anzahl\": {lieferungen.Count},");
                outputFile.WriteLine($"\t\"lieferungen\":");
                outputFile.WriteLine("\t[");

                for (int i = 0; i < lieferungen.Count; i++)
                {
                    outputFile.WriteLine("\t\t{");
                    outputFile.WriteLine($"\t\t\t\"datum\" : \"{lieferungen.ElementAt(i).Datum}\",");
                    outputFile.WriteLine($"\t\t\t\"sendungsnummer\" : \"{lieferungen.ElementAt(i).Sendungsnummer}\",");
                    outputFile.WriteLine($"\t\t\t\"plz\" : {Convert.ToInt32(lieferungen.ElementAt(i).PLZ)}");
                    if (i == lieferungen.Count - 1)
                    {
                        outputFile.WriteLine("\t\t}");
                    }
                    else
                    {
                        outputFile.WriteLine("\t\t},");
                    }
                }
                
                outputFile.WriteLine("\t]");
                outputFile.WriteLine("}");
            }
        }
    }
}
