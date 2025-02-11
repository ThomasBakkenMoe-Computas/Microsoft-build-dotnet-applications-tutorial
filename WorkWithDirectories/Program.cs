using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString());

Console.WriteLine(salesData.Total);

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

class SalesTotal
{
    public double Total { get; set; }
}


//string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
//
//FileInfo info = new FileInfo(fileName);
//
//Console.WriteLine($"Full name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Data: {info.CreationTime}");