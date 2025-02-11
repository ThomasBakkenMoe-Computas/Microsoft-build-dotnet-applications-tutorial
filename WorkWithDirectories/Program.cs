using System.Text.Json;
using System.IO;
using System.Collections.Generic;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDir = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDir);

var salesTotal = CalculateSalesTotal(salesFiles); // Add this line of code

File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json") {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data = JsonSerializer.Deserialize<SalesData?>(salesJson);

        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

record SalesData (double Total);

class SalesTotal
{
    public double Total { get; set; }
}


//string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
//
//FileInfo info = new FileInfo(fileName);
//
//Console.WriteLine($"Full name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Data: {info.CreationTime}");