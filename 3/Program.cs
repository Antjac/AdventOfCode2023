using System.Text;

string[] lines = File.ReadAllLines("./input.txt");
Dictionary<int, List<(int start,int end)>> lNumbers = new Dictionary<int, List<(int start,int end)>>();
Dictionary<int, List<int>> lSpecials = new Dictionary<int, List<int>>();
int l = 0;
int sum = 0;
foreach (string line in lines)
{
    l++;
    lNumbers[l] = new List<(int,int)>();
    lSpecials[l] = new List<int>();
    bool isNumber = false;
    for (int i = 0; i < line.Length; i++)
    {
        if (Char.IsDigit(line[i]))
        {
            if (!isNumber)
            {
                isNumber = true;
                lNumbers[l].Add((i+1,-1));
            }
            else
            {
                lNumbers[l][lNumbers[l].Count() - 1] = (lNumbers[l][lNumbers[l].Count() - 1].start, i);
            }
        }
        else
        {
            if (isNumber)
            {
                isNumber = false;
                lNumbers[l][lNumbers[l].Count() - 1] = (lNumbers[l][lNumbers[l].Count() - 1].start, i);
            }
        }

        if ((!Char.IsNumber(line[i])) && (!line[i].Equals('.')))
        {
            lSpecials[l].Add(i+1);
        }
    }
}

foreach (var line in lNumbers)
{

    foreach (var numb in line.Value)
    {
        bool isGood = false;
        var endCorrected = numb.end;
        if (endCorrected == -1)
        {
            endCorrected = lines[0].Length;
        }
        if (line.Key > 1)
        {
            //Check line above
            if (lSpecials[line.Key-1].Any(x => x >= numb.start - 1 && x <= endCorrected + 1 ))
            {
                isGood = true;
            }
        }

        if (line.Key < lNumbers.Count())
        {
            //check line below
            if (lSpecials[line.Key + 1].Any(x => x >= numb.start - 1 && x <= endCorrected + 1))
            {
                isGood = true;
            }
        }

        if (numb.start > 1)
        {
            //Check the left side
            if (lSpecials[line.Key].Any(x => x == numb.start - 1))
            {
                isGood = true;
            }
        }

        if (endCorrected < lines[0].Length)
        {
            //Check the right side
            if (lSpecials[line.Key].Any(x=> x == endCorrected + 1))
            {
                isGood = true;
            }
        }

        if (isGood)
        {
            StringBuilder o = new StringBuilder();
            for (var i = numb.start-1; i < endCorrected; i++)
            {
                o.Append(lines[line.Key-1][i]);
            }
            sum += int.Parse(o.ToString());
        }
    }

    Console.WriteLine(sum);
}

Console.WriteLine(sum);
