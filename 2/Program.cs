// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

var nbRed = 12;
var nbGreen = 13;
var nbBlue = 14;
var gameId = 0;
int s = 0;
string[] lines = File.ReadAllLines("./input.txt");
foreach (string line in lines)
{
    gameId++;
    string game = line.Split(": ")[1];
    string[] sets = game.Split(";");
    bool isOk = true;
    foreach (string set in sets)
    {
        string[] colors = set.Split(", ");
        int sumColors = 0;
        foreach (string color in colors)
        {
            int nb = int.Parse(color.Trim().Split(" ")[0]);
            sumColors += nb;
            string col = color.Trim().Split(" ")[1];

            if (nb > (col == "red" ? nbRed : col == "green" ? nbGreen : nbBlue))
            {
                isOk = false;
            }
        }
    }

    if (isOk)
    {
        s += gameId;
        Debug.WriteLine($"Game {gameId} is OK");
    }
}
Debug.WriteLine(s);