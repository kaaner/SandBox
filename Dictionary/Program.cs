using System.Xml.XPath;

Dictionary<string, int> ogrenciNotlari = new Dictionary<string, int>();
// Anahtar-değer ekleme
ogrenciNotlari["Ali"] = 85;
ogrenciNotlari["Ayşe"] = 92;
ogrenciNotlari["Mehmet"] = 78;
// Değere erişme
int aliNotu = ogrenciNotlari["Ali"];
Console.WriteLine($"alinotu = {aliNotu}");

foreach (KeyValuePair<string, int> pair in ogrenciNotlari)
{
    string key = pair.Key;
    int value = pair.Value;
    Console.WriteLine($"Key = {key}, Value = {value}");
    // Your code here
}