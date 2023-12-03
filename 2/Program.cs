// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

var nbMaxRed = 12;
var nbMaxGreen = 13;
var nbMaxBlue = 14;
var gameId = 0;
int s = 0;
int s2 = 0;
string[] lines = File.ReadAllLines("./input.txt");
foreach (string line in lines)
{
    gameId++;
    string game = line.Split(": ")[1];
    string[] sets = game.Split(";");
    bool isOk = true;
    int nbRed = 0;
    int nbGreen = 0;
    int nbBlue = 0;
    int maxBlue = 0;
    int maxRed = 0;
    int maxGreen = 0;
    foreach (string set in sets)
    {
        string[] colors = set.Split(", ");
        int sumColors = 0;
        foreach (string color in colors)
        {
            int nb = int.Parse(color.Trim().Split(" ")[0]);
            sumColors += nb;
            string col = color.Trim().Split(" ")[1];
            switch (col)
            {
                case "red":
                    nbRed = nb; 
                    break;
                case "blue":
                    nbBlue = nb;
                    break;
                case "green":
                    nbGreen = nb;
                    break;
            }

            if (nb > (col == "red" ? nbMaxRed : col == "green" ? nbMaxGreen : nbMaxBlue))
            {
                isOk = false;
            }

            if (col == "red" && maxRed < nbRed) maxRed = nb;
            if (col == "green" && maxGreen < nbGreen) maxGreen = nb;
            if (col == "blue" && maxBlue < nbBlue) maxBlue = nb;
        }
    }

    s2 += maxRed * maxBlue * maxGreen;
    if (isOk)
    {
        s += gameId;
        Debug.WriteLine($"Game {gameId} is OK");
    }
}
Debug.WriteLine(s);
Debug.WriteLine(s2);