// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.RegularExpressions;


Dictionary<int, (int indexMin, int indexMax)> d = new Dictionary<int, (int indexMin, int indexMax)>
{
    { 1, (-1,-1) },
    { 2, (-1,-1) },
    { 3, (-1,-1) },
    { 4, (-1,-1) },
    { 5, (-1,-1) },
    { 6, (-1,-1) },
    { 7, (-1,-1) },
    { 8, (-1,-1) },
    { 9, (-1,-1) }
};

string[] lines = File.ReadAllLines("./input.txt");
int s = 0;

Regex r = new Regex("[0 - 9]");
foreach (string line in lines)
{
    d[1] = (Math.Min((line.IndexOf("one")>-1 ? line.IndexOf("one") : int.MaxValue), (line.IndexOf("1") > -1 ? line.IndexOf("1") : int.MaxValue)), Math.Max((line.LastIndexOf("one") > -1 ? line.LastIndexOf("one") : -1), (line.LastIndexOf("1") > -1 ? line.LastIndexOf("1") : -1)));
    d[2] = (Math.Min((line.IndexOf("two") > -1 ? line.IndexOf("two") : int.MaxValue), (line.IndexOf("2") > -1 ? line.IndexOf("2") : int.MaxValue)), Math.Max((line.LastIndexOf("two") > -1 ? line.LastIndexOf("two") : -1), (line.LastIndexOf("2") > -1 ? line.LastIndexOf("2") : -1)));
    d[3] = (Math.Min((line.IndexOf("three") > -1 ? line.IndexOf("three") : int.MaxValue), (line.IndexOf("3") > -1 ? line.IndexOf("3") : int.MaxValue)), Math.Max((line.LastIndexOf("three") > -1 ? line.LastIndexOf("three") : -1), (line.LastIndexOf("3") > -1 ? line.LastIndexOf("3") : -1)));
    d[4] = (Math.Min((line.IndexOf("four") > -1 ? line.IndexOf("four") : int.MaxValue), (line.IndexOf("4") > -1 ? line.IndexOf("4") : int.MaxValue)), Math.Max((line.LastIndexOf("four") > -1 ? line.LastIndexOf("four") : -1), (line.LastIndexOf("4") > -1 ? line.LastIndexOf("4") : -1)));
    d[5] = (Math.Min((line.IndexOf("five") > -1 ? line.IndexOf("five") : int.MaxValue), (line.IndexOf("5") > -1 ? line.IndexOf("5") : int.MaxValue)), Math.Max((line.LastIndexOf("five") > -1 ? line.LastIndexOf("five") : -1), (line.LastIndexOf("5") > -1 ? line.LastIndexOf("5") : -1)));
    d[6] = (Math.Min((line.IndexOf("six") > -1 ? line.IndexOf("six") : int.MaxValue), (line.IndexOf("6") > -1 ? line.IndexOf("6") : int.MaxValue)), Math.Max((line.LastIndexOf("six") > -1 ? line.LastIndexOf("six") : -1), (line.LastIndexOf("6") > -1 ? line.LastIndexOf("6") : -1)));
    d[7] = (Math.Min((line.IndexOf("seven") > -1 ? line.IndexOf("seven") : int.MaxValue), (line.IndexOf("7") > -1 ? line.IndexOf("7") : int.MaxValue)), Math.Max((line.LastIndexOf("seven") > -1 ? line.LastIndexOf("seven") : -1), (line.LastIndexOf("7") > -1 ? line.LastIndexOf("7") : -1)));
    d[8] = (Math.Min((line.IndexOf("eight") > -1 ? line.IndexOf("eight") : int.MaxValue), (line.IndexOf("8") > -1 ? line.IndexOf("8") : int.MaxValue)), Math.Max((line.LastIndexOf("eight") > -1 ? line.LastIndexOf("eight") : -1), (line.LastIndexOf("8") > -1 ? line.LastIndexOf("8") : -1)));
    d[9] = (Math.Min((line.IndexOf("nine") > -1 ? line.IndexOf("nine") : int.MaxValue), (line.IndexOf("9") > -1 ? line.IndexOf("9") : int.MaxValue)), Math.Max((line.LastIndexOf("nine") > -1 ? line.LastIndexOf("nine") : -1), (line.LastIndexOf("9") > -1 ? line.LastIndexOf("9") : -1)));

    var t= d.OrderBy(x => x.Value.indexMin).First().Key * 10 + d.OrderByDescending(x => x.Value.indexMax).First().Key;
    s += t;

}

Debug.WriteLine(s);

